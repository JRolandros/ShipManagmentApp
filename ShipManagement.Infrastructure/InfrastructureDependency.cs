using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShipManagement.Application.Repositories;
using ShipManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Infrastructure
{
    public static class InfrastructureDependency
    {
        /// <summary>
        /// Call this extension method to inject Infrastructure library in the main project and register its repositories in the main service collection.
        /// This project is also used to create, migrate and seed the ShipManagement database.
        /// Here is the place add the repository in the sevice collection to make them available in the provider for injection.
        /// </summary>
        /// <param name="services">Service collection. provide by caller project</param>
        /// <param name="configuration">Used to import project configuration set in the appsetting.json</param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Add DB context and configure it for migration
            services.AddDbContext<ShipManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ShipManagementConnection"),
                    builder => builder.MigrationsAssembly(typeof(ShipManagementDbContext).Assembly.FullName)));

            // Register repository and later make them available widely in the project for injection.
            services.AddScoped<IShipManagementDbContext>(provider => provider.GetRequiredService<ShipManagementDbContext>());
            services.AddScoped<IShipRepository, ShipRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();

            return services;
        }
    }
}
