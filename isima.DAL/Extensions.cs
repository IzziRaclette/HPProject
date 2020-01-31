using isima.DAL;
using Isima.DTO;
using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isima.DAL
{
    public static class Extensions
    {
        public static Scene ToEntity(this SceneDto dto)
        {
            return new Scene
            {
                ID = dto.ID,
                Title = dto.Title,
                Content = dto.Content
            };
        }

        public static SceneDto ToDto(this Scene entity)
        {
            if (entity != null)
            {
                return new SceneDto
                {
                    ID = entity.ID,
                    Title = entity.Title,
                    Content = entity.Content
                };
            }
            return null;
        }
    }
}
