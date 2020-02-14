using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Isima.API.Models
{
    /// <summary>
    /// Scenb render to client 
    /// </summary>
    public class PlayerViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }


        /// <summary>
        /// Gets or sets the life.
        /// </summary>
        /// <value>
        /// The life.
        /// </value>
        public int Life { get; set; }

        /// <summary>
        /// Gets or sets the mana.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public int Mana { get; set; }
    }
}