using MediatR;
using ShipManagement.Application.Dtos;
using ShipManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Queries
{
    public class GetShipsQueryHandler : IRequestHandler<GetShipsQuery, List<ShipDto>>
    {
        private readonly IShipService _shipService;

        public GetShipsQueryHandler(IShipService shipService)
        {
            _shipService = shipService;
        }
        Task<List<ShipDto>> IRequestHandler<GetShipsQuery, List<ShipDto>>.Handle(GetShipsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ShipDto> result;

            if (request.ShipNumber.HasValue|| !string.IsNullOrEmpty(request.ShipName)|| request.ManagerId.HasValue) // We are requesting a search query
            {
                result=_shipService.SearchShips(request.ShipNumber,request.ManagerId, request.ShipName);             
            }
            else
            {
                result = _shipService.GetShips();
            }

            if (result == null)
                return null;

            if (request.Limit != 0)
            {
                var ships = result.Skip(request.OffSet).Take(request.Limit);

                return Task.FromResult(ships.ToList());
            }

            return Task.FromResult(result.ToList());
        }
    }
}
