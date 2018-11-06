using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehifleet.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    AddedOn = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    LocationCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationCode);
                });

            migrationBuilder.CreateTable(
                name: "VehicleSpecifications",
                columns: table => new
                {
                    AddedOn = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Mileage = table.Column<int>(nullable: false),
                    FuelConsumed = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Manufacturer = table.Column<string>(maxLength: 30, nullable: false),
                    Model = table.Column<string>(maxLength: 30, nullable: false),
                    ConfigurationCode = table.Column<string>(maxLength: 50, nullable: false),
                    Horsepower = table.Column<int>(nullable: false),
                    Seats = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    DistanceBetweenOilChange = table.Column<int>(nullable: false),
                    MaintenanceNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSpecifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    AddedOn = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Mileage = table.Column<int>(nullable: false),
                    FuelConsumed = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    IsManager = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Role = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: false),
                    LocationCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_LocationCode",
                        column: x => x.LocationCode,
                        principalTable: "Locations",
                        principalColumn: "LocationCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    AddedOn = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Mileage = table.Column<int>(nullable: false),
                    FuelConsumed = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleSpecificationId = table.Column<int>(nullable: false),
                    LocationCode = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    LicensePlate = table.Column<string>(maxLength: 20, nullable: false),
                    YearOfManufacture = table.Column<int>(nullable: false),
                    ChassisCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Locations_LocationCode",
                        column: x => x.LocationCode,
                        principalTable: "Locations",
                        principalColumn: "LocationCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleSpecifications_VehicleSpecificationId",
                        column: x => x.VehicleSpecificationId,
                        principalTable: "VehicleSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    AddedOn = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Mileage = table.Column<int>(nullable: false),
                    FuelConsumed = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    AddedOn = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Passed = table.Column<bool>(nullable: false),
                    Mileage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    AddedOn = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    InsuranceId = table.Column<string>(nullable: false),
                    Mileage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurances_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    AddedOn = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenances_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EmployeeId",
                table: "Bookings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ManagerId",
                table: "Bookings",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehicleId",
                table: "Bookings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationCode",
                table: "Employees",
                column: "LocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_VehicleId",
                table: "Inspections",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_VehicleId",
                table: "Insurances",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_VehicleId",
                table: "Maintenances",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LocationCode",
                table: "Vehicles",
                column: "LocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleSpecificationId",
                table: "Vehicles",
                column: "VehicleSpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Maintenances");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "VehicleSpecifications");
        }
    }
}
