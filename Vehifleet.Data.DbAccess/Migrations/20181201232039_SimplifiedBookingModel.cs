using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehifleet.Data.DbAccess.Migrations
{
    public partial class SimplifiedBookingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Employees_EmployeeId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Employees_ManagerId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ManagerId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Employees_EmployeeId",
                table: "Bookings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Employees_EmployeeId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ManagerId",
                table: "Bookings",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Employees_EmployeeId",
                table: "Bookings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Employees_ManagerId",
                table: "Bookings",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
