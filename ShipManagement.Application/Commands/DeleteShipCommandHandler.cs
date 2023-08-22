using MediatR;
using ShipManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Commands
{
    public class DeleteShipCommandHandler : IRequestHandler<DeleteShipCommand, int>
    {
        private readonly IShipService _shipService;

        public DeleteShipCommandHandler(IShipService shipService)
        {
            _shipService = shipService;
        }
        public Task<int> Handle(DeleteShipCommand request, CancellationToken cancellationToken)
        {
            var id = _shipService.DeleteShip(request.Id);

            return Task.FromResult(id);
        }
    }
}
