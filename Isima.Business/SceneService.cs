using isima.DAL;
using Isima.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.Business
{
    public class SceneService
    {
        public SceneDto GetScene(int ID)
        {
            using (SceneRepository _sceneRepo = new SceneRepository())
            {
                return _sceneRepo.GetScene(ID);
            }
        }
    }
}
