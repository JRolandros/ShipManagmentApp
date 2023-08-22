using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShipManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipManagement.Infrastructure.Configurations
{
    public class ManagerTableConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x=>x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();

            SeedData(builder);
        }

        private void SeedData(EntityTypeBuilder<Manager> builder)
        {
            builder.HasData(
                new Manager
                {
                    Id = 1,
                    Email = "Roland@gmail.com",
                    Name = "Roland",
                    Password = "roTest123"
                },
                new Manager
                {
                    Id = 2,
                    Email = "Wael@gmail.com",
                    Name = "Wael",
                    Password = "waelTest123"
                }
                );
        }
    }
}
