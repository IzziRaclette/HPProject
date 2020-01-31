using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isima.DAL
{
    public class SceneRepository : IDisposable
    {
        private readonly IsimaEntities _dbcontext = null;

        public SceneRepository()
        {
            _dbcontext = new IsimaEntities();
        }

        public SceneRepository(IsimaEntities context)
        {
            _dbcontext = context;
        }


        public SceneDto GetScene(int ID)
        {
            try
            {
                List<Scene> sceneEntities = _dbcontext.Scene.Where(x => x.ID == ID).ToList();
                return sceneEntities.Select(x => new SceneDto
                {
                    ID = x.ID,
                    Content = x.Content,
                    Title = x.Title
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
