using ShipManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Services
{
    public interface IShipService
    {
        IEnumerable<ShipDto> GetShips();

        IEnumerable<ShipDto> SearchShips(int? shipNumber,int? managerId=null,string? shipName=null);

        ShipDto AddShip(ShipDto ship);

        ShipDto UpdateShip(ShipDto ship);

        int DeleteShip(int id);

    }
}
