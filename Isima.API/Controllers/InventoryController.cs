using Isima.API.Models;
using Isima.Business;
using Isima.DTO;
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
    /// Inventory Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class InventoryController : ApiController
    {
        private readonly InventoryService _inventoryService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        public InventoryController()
        {
            _inventoryService = new InventoryService();
        }


        /// <summary>
        /// Get list of all items of inventory 
        /// </summary>
        /// <remarks>
        /// Get list of all items of inventory from the database no filtered
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> List of items of inventory</response>
        [ResponseType(typeof(IEnumerable<InventoryViewModel>))]
        public IHttpActionResult Get()
        {
            IList<InventoryDto> items = _inventoryService.GetInventory();
            IEnumerable<InventoryViewModel> inventoryList = items.Select(st => new InventoryViewModel
            {
                ID_item = st.ID_item
            });

            return Ok(inventoryList);

        }
    }
}
