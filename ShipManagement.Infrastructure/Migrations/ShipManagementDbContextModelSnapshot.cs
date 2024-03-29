﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShipManagement.Infrastructure;

#nullable disable

namespace ShipManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ShipManagementDbContext))]
    partial class ShipManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShipManagement.Domain.Entities.Manager", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Roland@gmail.com",
                            Name = "Roland",
                            Password = "roTest123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Wael@gmail.com",
                            Name = "Wael",
                            Password = "waelTest123"
                        });
                });

            modelBuilder.Entity("ShipManagement.Domain.Entities.Ship", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CreatedYear")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<decimal>("ShipLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("ShipWidth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("WeightGross")
                        .HasColumnType("float");

                    b.Property<double>("WeightNet")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ShipNumber")
                        .IsUnique();

                    b.ToTable("Ships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedYear = 0,
                            ManagerId = 1,
                            ShipLength = 60m,
                            ShipName = "555-Ship",
                            ShipNumber = 555,
                            ShipWidth = 20m,
                            WeightGross = 30.0,
                            WeightNet = 25.0
                        },
                        new
                        {
                            Id = 2,
                            CreatedYear = 0,
                            ManagerId = 1,
                            ShipLength = 50m,
                            ShipName = "565-Ship",
                            ShipNumber = 565,
                            ShipWidth = 20m,
                            WeightGross = 40.0,
                            WeightNet = 30.0
                        },
                        new
                        {
                            Id = 3,
                            CreatedYear = 0,
                            ManagerId = 2,
                            ShipLength = 68m,
                            ShipName = "878-Ship",
                            ShipNumber = 878,
                            ShipWidth = 40m,
                            WeightGross = 50.0,
                            WeightNet = 40.0
                        },
                        new
                        {
                            Id = 4,
                            CreatedYear = 0,
                            ManagerId = 1,
                            ShipLength = 20m,
                            ShipName = "999-Ship",
                            ShipNumber = 999,
                            ShipWidth = 15m,
                            WeightGross = 20.0,
                            WeightNet = 18.0
                        });
                });

            modelBuilder.Entity("ShipManagement.Domain.Entities.Ship", b =>
                {
                    b.HasOne("ShipManagement.Domain.Entities.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });
#pragma warning restore 612, 618
        }
    }
}
