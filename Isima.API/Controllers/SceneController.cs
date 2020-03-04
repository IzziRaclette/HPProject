using Isima.API.Models;
using Isima.Business;
using Isima.DTO;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace Isima.API.Controllers
{
    /// <summary>
    /// Student Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
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
        /// Get a Scene by its ID 
        /// </summary>
        /// <remarks>
        /// Get a Scene by its ID 
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> A Scene</response>
        [ResponseType(typeof(IEnumerable<SceneViewModel>))]
        public IHttpActionResult Get(int ID)
        {
            SceneDto sceneDto = _sceneService.GetScene(ID);
            //var actions = new Dictionary<String, SceneService.Action>();

            return Ok(new SceneViewModel
            {
                ID = sceneDto.ID,
                Content = sceneDto.Content,
                Title = sceneDto.Title
                //Title = SceneService.parseBytecode(sceneDto.Title, actions)
        });
        }
    }
}
