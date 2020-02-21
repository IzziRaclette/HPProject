using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class SceneService
    {
        public sealed class Action
        {
            private sealed class Operation
            {
                enum Type
                {
                    FLAG_SET,
                    FLAG_UNSET,
                    MOVE,
                    OBTAIN
                }

                private static readonly Dictionary<string, Type> types = new Dictionary<string, Type> {
                    { "FLAG_SET", Type.FLAG_SET },
                    { "FLAG_UNSET", Type.FLAG_UNSET },
                    { "MOVE", Type.MOVE },
                    { "OBTAIN", Type.OBTAIN }
                };
                private readonly Type type;
                private readonly string[] operands;

                public Operation(string expression)
                {
                    var words = expression.Split(new char[0]);
                    type = types[words[0]];
                    operands = words.Skip(1).ToArray();
                }

                public void Execute()
                {
                    switch (type)
                    {
                        case Type.FLAG_SET:
                        case Type.FLAG_UNSET:
                        case Type.MOVE:
                        case Type.OBTAIN:
                            throw new NotImplementedException();
                            break;
                    }
                }
            }

            private List<Operation> operations;

            public Action(string expression)
            {
                try
                {
                    operations = expression.Split(',').Cast<Operation>().ToList();
                } catch (Exception e)
                {
                    throw new FormatException("Action parse error", e);
                }
            }

            public void Execute()
            {
                operations.ForEach(operation => operation.Execute());
            }
        }

        // Whether we are skipping lines due to conditions
        private enum CondSkip { NONE, TO_ELSE, TO_ENDIF }
        private static readonly Regex actionRegex = new Regex("^\\s*(?<ID>[a-z0-9_-])\\s*:\\s*\\[(?<expression>[^\\]])\\]\\s+(?<text>(.+))\\s*$");
        public string parseBytecode(string bytecode, out Dictionary<string, Action> actions)
        {
            actions = new Dictionary<string, Action>();
            var output = new StringBuilder();

            int ifDepth = 0;
            CondSkip skip = CondSkip.NONE;
            int skipDepth = 0; // Initialization is actually unnecessary, but VS complains otherwise
            int lineNo = 0;
            foreach (string line in bytecode.Split('\n'))
            {
                lineNo++;

                // Is it a condition line?
                if (line.StartsWith("%"))
                {
                    if (line.StartsWith("%if"))
                    {
                        if (skipDepth == 0)
                        {
                            if (!evalCondition(line.Substring(3).Trim()))
                            {
                                skip = CondSkip.TO_ELSE;
                                skipDepth = 0;
                            }
                        }
                        else
                        {
                            skipDepth++;
                        }
                    }
                    else if (line.StartsWith("%else"))
                    {
                        if (ifDepth == 0) throw new FormatException(string.Format("Line {0}: %else found outside of a %if block", lineNo));

                        if (skipDepth == 0)
                        {
                            if (skip == CondSkip.TO_ELSE)
                            {
                                skip = CondSkip.NONE;
                            }
                            else
                            { // CondSkip.NONE
                                skip = CondSkip.TO_ENDIF;
                            }
                        }
                    }
                    else if (line.StartsWith("%endif"))
                    {
                        if (ifDepth == 0) throw new FormatException(string.Format("Line {0}: %endif found outside of a %if block", lineNo));

                        if (skipDepth != 0) skipDepth--;
                        ifDepth--;
                    }
                    else
                    {
                        throw new FormatException(string.Format("Line {0}: unknown condition command", lineNo));
                    }
                }
                // Process normal lines unless we're skipping them
                else if (skip == CondSkip.NONE)
                {
                    int readPos = 0;
                    while (true)
                    {
                        // Find how many chars until the next opening brace
                        int bracePos = line.IndexOf('{', readPos);
                        // Copy the chars to output as-is
                        output.Append(bracePos == -1 ? line.Substring(readPos) : line.Substring(readPos, bracePos - readPos));
                        // If that was all, stop
                        if (bracePos == -1) break;

                        int endBracePos = line.IndexOf('}', bracePos + 1);
                        if (endBracePos == -1) throw new FormatException(string.Format("Line {0}: brace at column {1} is not closed", lineNo, bracePos));
                        var matches = actionRegex.Match(line.Substring(bracePos + 1, endBracePos - bracePos + 1));
                        string ID = matches.Groups["ID"].Value, expression = matches.Groups["expression"].Value, text = matches.Groups["text"].Value;

                        actions.Add(ID, new Action(expression));
                        output.AppendFormat("{{{0} {1}}}", ID, text);
                        readPos = endBracePos + 1;
                    }
                    output.Append('\n');
                }
            }

            return output.ToString();
        }

        private static readonly Dictionary<string, Func<bool, bool, bool>> condOperators = new Dictionary<string, Func<bool, bool, bool>>
        {
            { "AND", (a,b) => a && b },
            { "OR" , (a,b) => a || b }
        };
        private static bool evalCondition(string condition)
        {
            if (condition.StartsWith("("))
            {
                int leftOpEnd = 0, depth = 1;
                while (depth != 0)
                {
                    leftOpEnd++;
                    switch (condition[leftOpEnd])
                    {
                        case '(':
                            depth++;
                            break;
                        case ')':
                            depth--;
                            break;
                    }
                }

                string[] rest = condition.Substring(leftOpEnd + 1).Split(new char[2], 2, StringSplitOptions.RemoveEmptyEntries);

                return condOperators[rest[0]](evalCondition(condition.Substring(1, leftOpEnd - 1)), evalCondition(rest[1]));
            }
            else
            {
                var operands = condition.Split(new char[0]);
                switch (operands[0])
                {
                    case "SET":
                        return  new FlagService().GetFlag(operands[1]).State;
                    case "UNSET":
                        return !new FlagService().GetFlag(operands[1]).State;
                    default:
                        throw new FormatException(string.Format("Unknown conditional operation `{0}`", operands[0]));
                }
            }
        }

        public SceneDto GetScene(int ID)
        {
            using (SceneRepository _sceneRepo = new SceneRepository())
            {
                return _sceneRepo.GetScene(ID);
            }
        }
    }
}
