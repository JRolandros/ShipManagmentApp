using ShipManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Infrastructure.Repositories
{
    public abstract class BaseAbstractRepository
    {
        protected readonly IShipManagementDbContext _dbContext;

        public BaseAbstractRepository(IShipManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new NullReferenceException("db can't be null");
        }
    }
}
