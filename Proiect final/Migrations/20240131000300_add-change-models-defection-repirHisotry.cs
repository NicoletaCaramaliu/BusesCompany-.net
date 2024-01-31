using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_final.Migrations
{
    /// <inheritdoc />
    public partial class addchangemodelsdefectionrepirHisotry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Defections");

            migrationBuilder.DropColumn(
                name: "RepairDate",
                table: "Defections");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "RepairHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RepairDate",
                table: "RepairHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "RepairHistories");

            migrationBuilder.DropColumn(
                name: "RepairDate",
                table: "RepairHistories");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Defections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RepairDate",
                table: "Defections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
