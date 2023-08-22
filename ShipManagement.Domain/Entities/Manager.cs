using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Domain.Entities
{
    public class Manager :BaseEntity
    {
        /// <summary>
        /// User name to display
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Username or login
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Paasword
        /// </summary>
        public string Password { get; set; }
    }
}
