using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class ItemRepository : IDisposable
    {
        private readonly IsimaEntities _dbcontext = null;

        public ItemRepository()
        {
            _dbcontext = new IsimaEntities();
        }

        public ItemRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }


        public ItemDto GetItem(int ID)
        {
            try
            {
                List<Item> itemEntities = _dbcontext.Item.Where(x => x.ID == ID).ToList();
                return itemEntities.Select(x => new ItemDto
                {
                    ID = x.ID,
                    Content = x.Content,
                    Name = x.Name
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
