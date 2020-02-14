using Isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class InventoryRepository : IDisposable
    {

        private readonly IsimaEntities _dbcontext = null;

        public InventoryRepository()
        {
            _dbcontext = new IsimaEntities();
        }

        public InventoryRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public List<InventoryDto> GetInventory()
        {
            try
            {
                //Get all items in inventory data line from database 
                List<Inventory> inventoryEntities = _dbcontext.Inventory.ToList();
                //transform to DTO, and send to upper layer
                return inventoryEntities.Select(x => new InventoryDto
                {
                    ID_item = x.ID_item,
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


    }
}
