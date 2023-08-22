using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShipManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ShipNumber = table.Column<int>(type: "int", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedYear = table.Column<int>(type: "int", nullable: false),
                    ShipLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShipWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightGross = table.Column<double>(type: "float", nullable: false),
                    WeightNet = table.Column<double>(type: "float", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Roland@gmail.com", "Roland", "roTest123" },
                    { 2, "Wael@gmail.com", "Wael", "waelTest123" }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "CreatedYear", "ManagerId", "ShipLength", "ShipName", "ShipNumber", "ShipWidth", "WeightGross", "WeightNet" },
                values: new object[,]
                {
                    { 1, 0, 1, 60m, "555-Ship", 555, 20m, 30.0, 25.0 },
                    { 2, 0, 1, 50m, "565-Ship", 565, 20m, 40.0, 30.0 },
                    { 3, 0, 2, 68m, "878-Ship", 878, 40m, 50.0, 40.0 },
                    { 4, 0, 1, 20m, "999-Ship", 999, 15m, 20.0, 18.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_Email",
                table: "Managers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ManagerId",
                table: "Ships",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipNumber",
                table: "Ships",
                column: "ShipNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
