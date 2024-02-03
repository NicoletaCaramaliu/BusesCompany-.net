using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_final.Migrations
{
    /// <inheritdoc />
    public partial class addchangerepairhistorykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairHistories",
                table: "RepairHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairHistories",
                table: "RepairHistories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RepairHistories_BusId",
                table: "RepairHistories",
                column: "BusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairHistories",
                table: "RepairHistories");

            migrationBuilder.DropIndex(
                name: "IX_RepairHistories_BusId",
                table: "RepairHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairHistories",
                table: "RepairHistories",
                columns: new[] { "BusId", "DefectionId" });
        }
    }
}
