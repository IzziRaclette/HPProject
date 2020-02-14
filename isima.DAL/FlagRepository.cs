using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class FlagRepository : IDisposable
    {
        private readonly IsimaEntities _dbcontext = null;

        public FlagRepository()
        {
            _dbcontext = new IsimaEntities();
        }

        public FlagRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }


        public FlagDto GetFlag(string Name)
        {
            try
            {
                List<Flag> flagEntities = _dbcontext.Flag.Where(x => x.Name == Name).ToList();
                return flagEntities.Select(x => new FlagDto
                {
                    Name = x.Name,
                    State = x.State
                }).ToList().ElementAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
