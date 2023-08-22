using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Domain.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Technical Id
        /// </summary>
        public int Id { get; set; }
    }
}
