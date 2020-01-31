using Isima.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Isima.API.Models
{
    /// <summary>
    /// Scenb render to client 
    /// </summary>
    public class ItemViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
    }
}