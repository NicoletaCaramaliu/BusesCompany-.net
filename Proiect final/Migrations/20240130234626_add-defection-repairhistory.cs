using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_final.Migrations
{
    /// <inheritdoc />
    public partial class adddefectionrepairhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Drivers_DriverId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_DriverId",
                table: "Adresses");

            migrationBuilder.AlterColumn<Guid>(
                name: "DriverId",
                table: "Adresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Defections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairHistories",
                columns: table => new
                {
                    BusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairHistories", x => new { x.BusId, x.DefectionId });
                    table.ForeignKey(
                        name: "FK_RepairHistories_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairHistories_Defections_DefectionId",
                        column: x => x.DefectionId,
                        principalTable: "Defections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_DriverId",
                table: "Adresses",
                column: "DriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairHistories_DefectionId",
                table: "RepairHistories",
                column: "DefectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Drivers_DriverId",
                table: "Adresses",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Drivers_DriverId",
                table: "Adresses");

            migrationBuilder.DropTable(
                name: "RepairHistories");

            migrationBuilder.DropTable(
                name: "Defections");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_DriverId",
                table: "Adresses");

            migrationBuilder.AlterColumn<Guid>(
                name: "DriverId",
                table: "Adresses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_DriverId",
                table: "Adresses",
                column: "DriverId",
                unique: true,
                filter: "[DriverId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Drivers_DriverId",
                table: "Adresses",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }
    }
}
