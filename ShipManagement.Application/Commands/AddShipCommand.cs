using MediatR;
using ShipManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Commands
{
    public class AddShipCommand: IRequest<ShipDto>
    {
        public ShipDto ShipDto { get; set; }
    }
}
