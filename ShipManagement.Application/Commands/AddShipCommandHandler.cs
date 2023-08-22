using MediatR;
using ShipManagement.Application.Dtos;
using ShipManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Commands
{
    /// <summary>
    /// Handler that deal with all add ship request and return the expected Ship added.
    /// </summary>
    public class AddShipCommandHandler : IRequestHandler<AddShipCommand, ShipDto>
    {
        private readonly IShipService _shipService;

        public AddShipCommandHandler(IShipService shipService)
        {
            _shipService = shipService;
        }
        public Task<ShipDto> Handle(AddShipCommand request, CancellationToken cancellationToken)
        {
            var dto = _shipService.AddShip(request.ShipDto);

            return Task.FromResult(dto);
        }
    }
}
