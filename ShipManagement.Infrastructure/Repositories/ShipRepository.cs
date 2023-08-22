using Microsoft.EntityFrameworkCore;
using ShipManagement.Application.Common;
using ShipManagement.Application.Repositories;
using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Infrastructure.Repositories
{
    public class ShipRepository : BaseAbstractRepository, IShipRepository
    {
        public ShipRepository(IShipManagementDbContext dbContext) : base(dbContext)
        {

        }
        public int DeleteShip(int id)
        {
            var toDelete = _dbContext.Ships.FirstOrDefault(x => x.Id == id);

            if (toDelete == null)
            {
                throw new ShipManagementException(404,$"Ship not found with this key {id}");
            }

            _dbContext.Ships.Remove(toDelete);

            _dbContext.SaveChanges();

            return toDelete.ShipNumber;
        }

        public IEnumerable<Ship> GetShips()
        {
            return _dbContext.Ships.Include(x=>x.Manager);
        }

        public Ship InsertShip(Ship ship)
        {
            _dbContext.Ships.Add(ship);

            _dbContext.SaveChanges();

            return ship;
        }

        public Ship UpdateShip(Ship ship)
        {
            var toUpdate = _dbContext.Ships.FirstOrDefault(x => x.Id == ship.Id); // Attach object to EF entity to enable DB modification

            if (toUpdate == null)
            {
                throw new ShipManagementException(404,"Ship not found");
            }

            //Update attached EF entity
            toUpdate.ShipNumber = ship.ShipNumber;
            toUpdate.ShipName = ship.ShipName;
            toUpdate.ShipWidth= ship.ShipWidth;
            toUpdate.ShipLength= ship.ShipLength;
            toUpdate.CreatedYear = ship.CreatedYear;
            toUpdate.ManagerId = ship.ManagerId;
            toUpdate.WeightGross = ship.WeightGross;
            toUpdate.WeightNet = ship.WeightNet;

            _dbContext.Ships.Update(toUpdate);

            _dbContext.SaveChanges();

            return toUpdate;
        }
    }
}
