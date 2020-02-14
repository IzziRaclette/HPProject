using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class PlayerRepository : IDisposable
    {
        private readonly IsimaEntities _dbcontext = null;

        public PlayerRepository()
        {
            _dbcontext = new IsimaEntities();
        }

        public PlayerRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }


        public PlayerDto GetPlayer(int ID)
        {
            try
            {
                List<Player> playerEntities = _dbcontext.Player.Where(x => x.ID == ID).ToList();
                return playerEntities.Select(x => new PlayerDto
                {
                    ID = x.ID,
                    Life = x.Life,
                    Mana = x.Mana
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
