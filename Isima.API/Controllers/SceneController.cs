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
    public class SceneController : ApiController
    {
        private readonly SceneService _sceneService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneController"/> class.
        /// </summary>
        public SceneController()
        {
            _sceneService = new SceneService();
        }


        /// <summary>
        /// Get a scene by its ID 
        /// </summary>
        /// <remarks>
        /// Get a scene by its ID 
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> A scene</response>
        [ResponseType(typeof(IEnumerable<SceneViewModel>))]
        public IHttpActionResult Get(int ID)
        {
            SceneDto sceneDto = _sceneService.GetScene(ID);

            return Ok(new SceneViewModel
            {
                ID = sceneDto.ID,
                Content = sceneDto.Content,
                Title = sceneDto.Title
            });
        }
    }
}
