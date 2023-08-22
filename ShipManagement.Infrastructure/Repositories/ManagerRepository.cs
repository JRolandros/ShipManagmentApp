using ShipManagement.Application.Repositories;
using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Infrastructure.Repositories
{
    public class ManagerRepository : BaseAbstractRepository, IManagerRepository
    {
        public ManagerRepository(IShipManagementDbContext dbContext) : base(dbContext)
        {
            
        }
        public Manager? GetManagerById(int managerId)
        {
            return _dbContext.Managers?.FirstOrDefault(x => x.Id == managerId);
        }

        public Manager GetUserByEmail(string email)
        {
            return _dbContext.Managers?.FirstOrDefault(x => x.Email == email);
        }
    }
}
