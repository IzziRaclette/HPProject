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
    /// Flag Endpoint
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class FlagController : ApiController
    {
        private readonly FlagService _flagService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="FlagController"/> class.
        /// </summary>
        public FlagController()
        {
            _flagService = new FlagService();
        }


        /// <summary>
        /// Get a Flag by its Name
        /// </summary>
        /// <remarks>
        /// Get a Flag by its Name
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"> A Flag</response>
        [ResponseType(typeof(IEnumerable<FlagViewModel>))]
        public IHttpActionResult Get(string Name)
        {
            FlagDto flagDto = _flagService.GetFlag(Name);

            return Ok(new FlagViewModel
            {
                Name = flagDto.Name,
                State = flagDto.State

            });
        }
    }
}
