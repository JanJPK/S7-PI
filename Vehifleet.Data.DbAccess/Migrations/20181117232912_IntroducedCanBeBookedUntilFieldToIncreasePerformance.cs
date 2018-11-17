using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehifleet.Data.DbAccess.Migrations
{
    public partial class IntroducedCanBeBookedUntilFieldToIncreasePerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CanBeBookedUntil",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanBeBookedUntil",
                table: "Vehicles");
        }
    }
}
