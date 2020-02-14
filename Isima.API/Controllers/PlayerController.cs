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
    /// Player Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class PlayerController : ApiController
    {
        private readonly PlayerService _playerService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerController"/> class.
        /// </summary>
        public PlayerController()
        {
            _playerService = new PlayerService();
        }


        /// <summary>
        /// Get a Player by its ID 
        /// </summary>
        /// <remarks>
        /// Get a Player by its ID 
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> A Player</response>
        [ResponseType(typeof(IEnumerable<PlayerViewModel>))]
        public IHttpActionResult Get(int ID)
        {
            PlayerDto playerDto = _playerService.GetPlayer(ID);

            return Ok(new PlayerViewModel
            {
                ID = playerDto.ID,
                Life = playerDto.Life,
                Mana = playerDto.Mana
            });
        }
    }
}
