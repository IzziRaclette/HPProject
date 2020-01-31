using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class ItemService
    {
        public ItemDto GetItem(int ID)
        {
            using (ItemRepository _itemRepo = new ItemRepository())
            {
                return _itemRepo.GetItem(ID);
            }
        }
    }
}
