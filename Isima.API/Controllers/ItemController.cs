using Isima.API.Models;
using Isima.Business;
using Isima.DTO;
using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Isima.API.Controllers
{
    /// <summary>
    /// Student Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ItemController : ApiController
    {
        private readonly ItemService _itemService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        public ItemController()
        {
            _itemService = new ItemService();
        }


        /// <summary>
        /// Get a Item by its ID 
        /// </summary>
        /// <remarks>
        /// Get a Item by its ID 
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> A Item</response>
        [ResponseType(typeof(IEnumerable<ItemViewModel>))]
        public IHttpActionResult Get(int ID)
        {
            ItemDto itemDto = _itemService.GetItem(ID);

            return Ok(new ItemViewModel
            {
                ID = itemDto.ID,
                Content = itemDto.Content,
                Name = itemDto.Name
            });
        }
    }
}
