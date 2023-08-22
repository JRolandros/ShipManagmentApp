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
    public class ShipTableConfiguration : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).ValueGeneratedNever();
            builder.Property(e=>e.ShipNumber).IsRequired();
            builder.HasIndex(e => e.ShipNumber).IsUnique(); // avoid duplicate values for ship number
            builder.Property(e=>e.ShipName).IsRequired();
            builder.Property(e => e.ShipLength).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.ShipWidth).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.ManagerId).IsRequired();

            builder.HasOne(e => e.Manager).WithMany().HasForeignKey(x => x.ManagerId);

            SeedData(builder);

        }

        public void SeedData(EntityTypeBuilder<Ship> builder)
        {
            //Fake Data for tests

            builder.HasData(
                new Ship
                {
                    Id = 1,
                    ShipNumber = 555,
                    ShipName = "555-Ship",
                    ManagerId = 1,
                    ShipLength = 60,
                    ShipWidth=20,
                    WeightGross=30,
                    WeightNet=25
                },
                new Ship
                {
                    Id=2,
                    ShipNumber = 565,
                    ShipName = "565-Ship",
                    ManagerId = 1,
                    ShipLength = 50,
                    ShipWidth = 20,
                    WeightGross = 40,
                    WeightNet = 30
                },
                new Ship
                {
                    Id=3,
                    ShipNumber = 878,
                    ShipName = "878-Ship",
                    ManagerId = 2,
                    ShipLength = 68,
                    ShipWidth = 40,
                    WeightGross = 50,
                    WeightNet = 40
                },
                new Ship
                {
                    Id=4,
                    ShipNumber = 999,
                    ShipName = "999-Ship",
                    ManagerId = 1,
                    ShipLength = 20,
                    ShipWidth = 15,
                    WeightGross = 20,
                    WeightNet = 18
                }
                );
        }
    }
}
