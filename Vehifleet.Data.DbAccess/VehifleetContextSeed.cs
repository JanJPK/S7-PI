using System;
using System.Collections.Generic;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.DbAccess
{
    public static class VehifleetContextSeed
    {
        public static void CleanDatabase(this VehifleetContext context)
        {
            context.Bookings.RemoveRange(context.Bookings);
            context.CostCenters.RemoveRange(context.CostCenters);
            context.Employees.RemoveRange(context.Employees);
            context.Inspections.RemoveRange(context.Inspections);
            context.Insurances.RemoveRange(context.Insurances);
            context.Locations.RemoveRange(context.Locations);
            context.Maintenances.RemoveRange(context.Maintenances);
            context.Vehicles.RemoveRange(context.Vehicles);
            context.VehicleSpecifications.RemoveRange(context.VehicleSpecifications);
            context.SaveChanges();
        }

        public static void SeedDatabase(this VehifleetContext context)
        {            
            var locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Brzozowa 45",
                    City = "Wrocław",
                    LocationCode = "WRO-1",
                },
                new Location
                {
                    Id = 2,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Świerkowa 21",
                    City = "Wrocław",
                    LocationCode = "WRO-2",
                },
                new Location
                {
                    Id = 3,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Smogowa 96",
                    City = "Kraków",
                    LocationCode = "KRK-1",
                },
                new Location
                {
                    Id = 4,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Lipowa 88",
                    City = "Wrocław",
                    LocationCode = "WRO-3",
                },
                new Location
                {
                    Id = 1,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Garncarska 4",
                    City = "Opole",
                    LocationCode = "OPO-1",
                }
            };
            var costCenters = new List<CostCenter>
            {
                new CostCenter
                {
                    Id = 1,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    CostCenterCode = "IT"
                },
                new CostCenter
                {
                    Id = 2,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    CostCenterCode = "HR"
                },
                new CostCenter
                {
                    Id = 3,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    CostCenterCode = "MRK-1"
                },
            };
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    IsAdministrator = true,
                    Name = "Jan",
                    LastName = "Pajdak",
                    Role = "Head of IT",
                    CostCenterId = 1,
                    Username = "admin",
                    PasswordSalt = Convert.FromBase64String("Tuas4ANg37qH/2Fe8ehn1QgpG8GfBn/jKiDLCkX/u6U="),
                    PasswordHash = Convert.FromBase64String("trTTG4JwPqG6W22XRAjqS6zoWJJZ4MfKkM1xlJppTOw="),
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,                   
                },
                new Employee
                {
                    Id = 2,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    IsAdministrator = false,
                    Name = "Łukasz",
                    LastName = "Dzik",
                    Role = "HR Advisor",
                    CostCenterId = 2,
                    Username = "ldzik",
                    PasswordSalt = Convert.FromBase64String("HU9o4lh1afzrP26OgcvI+gtvAx0KbD4YF+W22qpb/5c="),
                    PasswordHash = Convert.FromBase64String("tKdjFaA2veWxSR47YkFcvdIxk5mwDlhRbxeDwAMDO+Q="),
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                },
                new Employee
                {
                    Id = 3,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    IsAdministrator = true,
                    Name = "Krzysztof",
                    LastName = "Sarna",
                    Role = "Head of IT",
                    CostCenterId = 3,
                    Username = "ksarna",
                    PasswordSalt = Convert.FromBase64String("iSaAQFSnQ55a7kBQVXLG4xlToDRfBDn4xDAKKbYcwqE="),
                    PasswordHash = Convert.FromBase64String("6Mo8Svl9gRNEYLmewQdwiu5wRxjM6Zeug6Cdc8S8a7I="),
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                },
                new Employee
                {
                    Id = 4,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    IsAdministrator = false,
                    Name = "Wojciech",
                    LastName = "Struś",
                    CostCenterId = 3,
                    Username = "wstrus",
                    PasswordSalt = Convert.FromBase64String("2x6PLBVWyxXke+62mifu7rcwHaItMdCSIcfT8cQ+e/o="),
                    PasswordHash = Convert.FromBase64String("YWaTtJLU/qUViifqrelfZryAewhEHFaohunFWsGpwHQ="),
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                }
            };
            var vehicleSpecifications = new List<VehicleSpecification>
            {
                new VehicleSpecification
                {
                    Id = 1,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "Focus",
                    ConfigurationCode = "FF2018184",
                    Horsepower = 115,
                    Seats = 4,
                    Weight = 1200,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    DistanceBetweenOilChange = 15000
                },
                new VehicleSpecification
                {
                    Id = 2,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "Focus",
                    ConfigurationCode = "FF2018154",
                    Horsepower = 85,
                    Seats = 4,
                    Weight = 1150,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    DistanceBetweenOilChange = 14000
                },
                new VehicleSpecification
                {
                    Id = 3,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "Mondeo",
                    ConfigurationCode = "FM2018184",
                    Horsepower = 155,
                    Seats = 4,
                    Weight = 1300,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    DistanceBetweenOilChange = 15000
                },
                new VehicleSpecification
                {
                    Id = 4,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Toyota",
                    Model = "Auris",
                    ConfigurationCode = "TA2018174",
                    Horsepower = 115,
                    Seats = 4,
                    Weight = 1300,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    DistanceBetweenOilChange = 17000
                },
                new VehicleSpecification
                {
                    Id = 5,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Toyota",
                    Model = "Corolla",
                    ConfigurationCode = "TC2018144",
                    Horsepower = 90,
                    Seats = 4,
                    Weight = 1270,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    DistanceBetweenOilChange = 15000
                },
            };
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 1,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    VehicleSpecificationId = 1,
                    ChassisCode = "FF2018123456",
                    LicensePlate = "WRO 234L",
                    YearOfManufacture = 2018,
                    Status = VehicleStatus.Available,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0                 
                },
                new Vehicle
                {
                    Id = 2,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    VehicleSpecificationId = 1,
                    ChassisCode = "FF2018125556",
                    LicensePlate = "WRO 22GF",
                    YearOfManufacture = 2018,
                    Status = VehicleStatus.Available,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
                },
                new Vehicle
                {
                    Id = 3,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    VehicleSpecificationId = 1,
                    ChassisCode = "FF201833443",
                    LicensePlate = "WRO KL32",
                    YearOfManufacture = 2018,
                    Status = VehicleStatus.Available,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
                },
                new Vehicle
                {
                    Id = 4,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    VehicleSpecificationId = 3,
                    ChassisCode = "FM2018122136",
                    LicensePlate = "WRO 3DE1",
                    YearOfManufacture = 2018,
                    Status = VehicleStatus.Available,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
                },
                new Vehicle
                {
                    Id = 5,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    VehicleSpecificationId = 3,
                    ChassisCode = "FM2018133256",
                    LicensePlate = "WRO FD32",
                    YearOfManufacture = 2018,
                    Status = VehicleStatus.Available,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
                },

            };
            var insurances = new List<Insurance>
            {
                new Insurance
                {
                    Id = 1,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 800,
                    StartDate = new DateTime(2018, 1, 1),
                    ExpirationDate = new DateTime(2019, 1, 1),
                    InsuranceId = "FXA-2018-1-1-1343",
                    VehicleId = 1,
                    Mileage = vehicles[0].Mileage
                },
                new Insurance
                {
                    Id = 2,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 800,
                    StartDate = new DateTime(2018, 1, 1),
                    ExpirationDate = new DateTime(2019, 1, 1),
                    InsuranceId = "FXA-2018-1-1-1344",
                    VehicleId = 2,
                    Mileage = vehicles[1].Mileage
                },
                new Insurance
                {
                    Id = 3,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 800,
                    StartDate = new DateTime(2018, 1, 1),
                    ExpirationDate = new DateTime(2019, 1, 1),
                    InsuranceId = "FXA-2018-1-1-1345",
                    VehicleId = 3,
                    Mileage = vehicles[2].Mileage
                },
                new Insurance
                {
                    Id = 4,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 900,
                    StartDate = new DateTime(2018, 4, 1),
                    ExpirationDate = new DateTime(2019, 4, 1),
                    InsuranceId = "ABB-2018-4-1-4324",
                    VehicleId = 4,
                    Mileage = vehicles[3].Mileage
                },
                new Insurance
                {
                    Id = 5,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 900,
                    StartDate = new DateTime(2018, 4, 1),
                    ExpirationDate = new DateTime(2019, 4, 1),
                    InsuranceId = "ABB-2018-4-1-4325",
                    VehicleId = 5,
                    Mileage = vehicles[4].Mileage
                }
            };
            var inspections = new List<Inspection>
            {
                new Inspection
                {
                    Id = 1,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 800,
                    StartDate = new DateTime(2018, 1, 1),
                    ExpirationDate = new DateTime(2019, 1, 1),
                    VehicleId = 1,
                    Mileage = vehicles[0].Mileage,
                    Passed = true
                },
                new Inspection
                {
                    Id = 2,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 800,
                    StartDate = new DateTime(2018, 1, 1),
                    ExpirationDate = new DateTime(2019, 1, 1),
                    VehicleId = 2,
                    Mileage = vehicles[1].Mileage,
                    Passed = true
                },
                new Inspection
                {
                    Id = 3,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 800,
                    StartDate = new DateTime(2018, 1, 1),
                    ExpirationDate = new DateTime(2019, 1, 1),
                    VehicleId = 3,
                    Mileage = vehicles[2].Mileage,
                    Passed = true
                },
                new Inspection
                {
                    Id = 4,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 900,
                    StartDate = new DateTime(2018, 4, 1),
                    ExpirationDate = new DateTime(2019, 4, 1),
                    VehicleId = 4,
                    Mileage = vehicles[3].Mileage,
                    Passed = true
                },
                new Inspection
                {
                    Id = 5,
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 900,
                    StartDate = new DateTime(2018, 4, 1),
                    ExpirationDate = new DateTime(2019, 4, 1),
                    VehicleId = 5,
                    Mileage = vehicles[4].Mileage,
                    Passed = true,
                }
            };

            context.Locations.AddRange(locations);
            context.CostCenters.AddRange(costCenters);
            context.Employees.AddRange(employees);
            context.VehicleSpecifications.AddRange(vehicleSpecifications);
            context.Vehicles.AddRange(vehicles);
            context.Insurances.AddRange(insurances);
            context.Inspections.AddRange(inspections);
            context.SaveChanges();
        }
    }
}
