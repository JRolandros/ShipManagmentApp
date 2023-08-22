using Microsoft.EntityFrameworkCore;
using ShipManagement.Application.Repositories;
using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Infrastructure
{
    public class ShipManagementDbContext : DbContext, IShipManagementDbContext
    {
        public ShipManagementDbContext(DbContextOptions<ShipManagementDbContext> dbCtxOptions) : base(dbCtxOptions)
        {

        }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Ship> Ships { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
