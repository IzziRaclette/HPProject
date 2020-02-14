using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class FlagService
    {
        public FlagDto GetFlag(string Name)
        {
            using (FlagRepository _flagRepo = new FlagRepository())
            {
                return _flagRepo.GetFlag(Name);
            }
        }
    }
}
