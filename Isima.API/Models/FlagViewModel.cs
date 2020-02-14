using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Isima.API.Models
{
    /// <summary>
    /// Scenb render to client 
    /// </summary>
    public class FlagViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public bool State { get; set; }

    }
}