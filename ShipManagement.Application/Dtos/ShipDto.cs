using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Dtos
{
    public class ShipDto
    {
        public int Id { get; set; }
        /// <summary>
        /// Ship number
        /// </summary>
        public int ShipNumber { get; set; }

        /// <summary>
        /// Ship name
        /// </summary>
        public string ShipName { get; set; }

        /// <summary>
        /// Year of construction of the ship
        /// </summary>
        public int CreatedYear { get; set; }

        /// <summary>
        /// Ship length in metter
        /// </summary>
        public double ShipLength { get; set; }

        /// <summary>
        /// Ship width in metter
        /// </summary>
        public double ShipWidth { get; set; }

        /// <summary>
        /// Ship gross weight in tons
        /// </summary>
        public double WeightGross { get; set; }

        /// <summary>
        /// Ship net weight in tons
        /// </summary>
        public double WeightNet { get; set; }

        /// <summary>
        /// Navigation property
        /// </summary>
        public Manager Manager { get; set; }


    }
}
