using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class PlayerService
    {
        public PlayerDto GetPlayer(int ID)
        {
            using (PlayerRepository _playerRepo = new PlayerRepository())
            {
                return _playerRepo.GetPlayer(ID);
            }
        }
    }
}
