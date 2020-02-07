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

        public static Item ToEntity(this ItemDto dto)
        {
            return new Item
            {
                ID = dto.ID,
                Name = dto.Name,
                Content = dto.Content
            };
        }

        public static ItemDto ToDto(this Item entity)
        {
            if (entity != null)
            {
                return new ItemDto
                {
                    ID = entity.ID,
                    Name = entity.Name,
                    Content = entity.Content
                };
            }
            return null;
        }



        public static Inventory ToEntity(this InventoryDto dto)
        {
            return new Inventory
            {
                ID_item = dto.ID_item
            };
        }

        public static InventoryDto ToDto(this Inventory entity)
        {
            if (entity != null)
            {
                return new InventoryDto
                {
                    ID_item = entity.ID_item
                };
            }
            return null;
        }
    }
}


