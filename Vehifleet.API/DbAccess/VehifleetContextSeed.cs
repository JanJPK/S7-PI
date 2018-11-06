using System;
using System.Collections.Generic;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.API.DbAccess
{
    public static class VehifleetContextSeed
    {
        public static void CleanDatabase(this VehifleetContext context)
        {
            context.Insurances.RemoveRange(context.Insurances);
            context.Inspections.RemoveRange(context.Inspections);
            context.Vehicles.RemoveRange(context.Vehicles);
            context.VehicleSpecifications.RemoveRange(context.VehicleSpecifications);
            context.Employees.RemoveRange(context.Employees);
            context.Locations.RemoveRange(context.Locations);
            context.Maintenances.RemoveRange(context.Maintenances);
            context.Bookings.RemoveRange(context.Bookings);
            context.SaveChanges();
        }

        public static void SeedDatabase(this VehifleetContext context)
        {
            var locations = new List<Location>
            {
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Brzozowa 45",
                    City = "Wrocław",
                    LocationCode = "WRO-1",
                },
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Świerkowa 21",
                    City = "Wrocław",
                    LocationCode = "WRO-2",
                },
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Smogowa 96",
                    City = "Kraków",
                    LocationCode = "KRK-1",
                },
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Lipowa 88",
                    City = "Wrocław",
                    LocationCode = "WRO-3",
                },
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Garncarska 4",
                    City = "Opole",
                    LocationCode = "OPO-1",
                }
            };
            context.Locations.AddRange(locations);
            var vehicleSpecifications = new List<VehicleSpecification>
            {
                new VehicleSpecification
                {
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
            context.VehicleSpecifications.AddRange(vehicleSpecifications);
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    IsManager = true,
                    Name = "Jan",
                    LastName = "Pajdak",
                    Role = "Administrator",
                    Department = "IT",
                    Username = "admin",
                    PasswordSalt = Convert.FromBase64String("Tuas4ANg37qH/2Fe8ehn1QgpG8GfBn/jKiDLCkX/u6U="),
                    PasswordHash = Convert.FromBase64String("trTTG4JwPqG6W22XRAjqS6zoWJJZ4MfKkM1xlJppTOw="),
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                },
                new Employee
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    IsManager = false,
                    Name = "Łukasz",
                    LastName = "Dzik",
                    Role = "HR Advisor",
                    Department = "HR",
                    Username = "ldzik",
                    PasswordSalt = Convert.FromBase64String("HU9o4lh1afzrP26OgcvI+gtvAx0KbD4YF+W22qpb/5c="),
                    PasswordHash = Convert.FromBase64String("tKdjFaA2veWxSR47YkFcvdIxk5mwDlhRbxeDwAMDO+Q="),
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                },
                new Employee
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    IsManager = true,
                    Name = "Krzysztof",
                    LastName = "Sarna",                    
                    Department = "Sales",
                    Username = "ksarna",
                    PasswordSalt = Convert.FromBase64String("iSaAQFSnQ55a7kBQVXLG4xlToDRfBDn4xDAKKbYcwqE="),
                    PasswordHash = Convert.FromBase64String("6Mo8Svl9gRNEYLmewQdwiu5wRxjM6Zeug6Cdc8S8a7I="),
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                },
                new Employee
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    IsManager = false,
                    Name = "Wojciech",
                    LastName = "Struś",
                    Department = "Sales",
                    Username = "wstrus",
                    PasswordSalt = Convert.FromBase64String("2x6PLBVWyxXke+62mifu7rcwHaItMdCSIcfT8cQ+e/o="),
                    PasswordHash = Convert.FromBase64String("YWaTtJLU/qUViifqrelfZryAewhEHFaohunFWsGpwHQ="),
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                }
            };
            context.Employees.AddRange(employees);
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
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
            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();

            var insurances = new List<Insurance>
            {
                new Insurance
                {
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
            context.Insurances.AddRange(insurances);
            var inspections = new List<Inspection>
            {
                new Inspection
                {
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
            context.Inspections.AddRange(inspections);
            context.SaveChanges();
        }
    }
}
