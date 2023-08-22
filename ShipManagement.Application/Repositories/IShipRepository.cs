using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Application.Repositories
{
    public interface IShipRepository
    {
        IEnumerable<Ship> GetShips();

        Ship InsertShip(Ship ship);
        Ship UpdateShip(Ship ship);

        int DeleteShip(int id);
    }
}
