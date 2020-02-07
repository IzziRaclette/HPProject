using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class InventoryService
    {
        public IList<InventoryDto> GetInventory()
        {
            using (InventoryRepository _studentRepo = new InventoryRepository())
            {
                return _studentRepo.GetInventory();
            }
        }
    }
}