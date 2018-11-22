using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehifleet.Data.DbAccess.Migrations
{
    public partial class AddedInitialPurchaseCostToVehicleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PurchaseCost",
                table: "VehicleModels",
                type: "decimal(16, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseCost",
                table: "VehicleModels");
        }
    }
}
