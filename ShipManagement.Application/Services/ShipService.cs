using AutoMapper;
using Microsoft.Extensions.Logging;
using ShipManagement.Application.Dtos;
using ShipManagement.Application.Repositories;
using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Services
{
    /// <summary>
    /// Service to handle ship management activities. Business need is met here!
    /// </summary>
    public class ShipService : IShipService
    {
        private readonly ILogger<ShipService> _logger;
        private readonly IShipRepository _shipRepo;
        private readonly IMapper _mapper;

        public ShipService(ILogger<ShipService> logger, IShipRepository shipRepository, IMapper mapper)
        {
            _logger = logger;
            _shipRepo = shipRepository;
            _mapper = mapper;
        }

        public ShipDto AddShip(ShipDto shipDto)
        {
            if(shipDto == null) throw new ArgumentNullException(nameof(shipDto));

            var ship = _mapper.Map<Ship>(shipDto);

            _logger.LogInformation("Inserting new ship");

            var inserted=_shipRepo.InsertShip(ship);

            _logger.LogInformation("Ship inserted");

            var dto = _mapper.Map<ShipDto>(inserted);
            return dto;
        }

        public int DeleteShip(int id)
        {
            _logger.LogInformation("Deleting ship");

            int deleted=_shipRepo.DeleteShip(id);

            _logger.LogInformation("Ship deleted");

            return deleted;
        }

        public IEnumerable<ShipDto> GetShips()
        {
            _logger.LogInformation("Get all ships");

            var all=_shipRepo.GetShips();

            _logger.LogInformation("All ship fetched");

            var dtos = _mapper.Map<IEnumerable<ShipDto>>(all);

            return dtos;
        }

        public IEnumerable<ShipDto> SearchShips(int? shipNumber, int? managerId = null, string? shipName = null)
        {
            _logger.LogInformation("Search start");

            var filtered = _shipRepo.GetShips();

            if (filtered != null && filtered.Count() > 0 && shipNumber!=null)
            {
                _logger.LogInformation($"filter by key ShipNumber={shipNumber}");

                filtered = filtered.Where(x => x.ShipNumber == shipNumber);
            }

            if(filtered!=null && filtered.Count()>0 && managerId!=null)
            {
                _logger.LogInformation($"filter by key ManagerId={managerId}");

                filtered = filtered.Where(x => x.ManagerId == managerId);
            }

            if (filtered != null && filtered.Count() > 0 && shipName != null)
            {
                _logger.LogInformation($"filter by key ShipName={shipName}");

                filtered = filtered.Where(x => x.ShipName == shipName);
            }

            var dtos = _mapper.Map<IEnumerable<ShipDto>>(filtered);

            _logger.LogInformation("Search end");

            return dtos;
        }

        public ShipDto UpdateShip(ShipDto shipDto)
        {
            _logger.LogInformation("Updating ship");

            var ship = _mapper.Map<Ship>(shipDto);

            var updated=_shipRepo.UpdateShip(ship);

            var dto = _mapper.Map<ShipDto>(updated);

            _logger.LogInformation($"Ship number={updated.ShipNumber} updated");

            return dto;

        }
    }
}
