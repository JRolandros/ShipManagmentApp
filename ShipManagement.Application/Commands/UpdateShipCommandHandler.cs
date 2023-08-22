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
    /// This Handler is listening to any update request that will be sent by mediator from the API.
    /// </summary>
    public class UpdateShipCommandHandler : IRequestHandler<UpdateShipCommand, ShipDto>
    {
        private readonly IShipService _shipService;

        public UpdateShipCommandHandler(IShipService shipService)
        {
            _shipService = shipService;
        }

        public Task<ShipDto> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
        {
            var dto = _shipService.UpdateShip(request.ShipDto);

            return Task.FromResult(dto);
        }
    }
}
