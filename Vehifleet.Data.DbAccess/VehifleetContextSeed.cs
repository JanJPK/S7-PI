using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.DbAccess
{
    public static class VehifleetContextSeed
    {
        private static readonly Random rng = new Random();

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

        /*
        public static void AddEmployees(this VehifleetContext context)
        {
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
            context.SaveChanges();
        }
        */

        public static void AddVehicleSpecifications(this VehifleetContext context)
        {
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
                new VehicleSpecification
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "C-Max",
                    ConfigurationCode = "FC2014184",
                    Horsepower = 105,
                    Seats = 5,
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
                    Manufacturer = "Ford",
                    Model = "S-Max",
                    ConfigurationCode = "FS2012184",
                    Horsepower = 105,
                    Seats = 6,
                    Weight = 1400,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    DistanceBetweenOilChange = 15000
                },
                new VehicleSpecification
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Skoda",
                    Model = "Superb",
                    ConfigurationCode = "SS185184",
                    Horsepower = 185,
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
                    Manufacturer = "Skoda",
                    Model = "Octavia",
                    ConfigurationCode = "SO14184",
                    Horsepower = 120,
                    Seats = 4,
                    Weight = 1250,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    DistanceBetweenOilChange = 15000
                },
                new VehicleSpecification
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Skoda",
                    Model = "Rapid",
                    ConfigurationCode = "SR14184",
                    Horsepower = 90,
                    Seats = 4,
                    Weight = 1100,
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    DistanceBetweenOilChange = 15000
                },
            };
            context.VehicleSpecifications.AddRange(vehicleSpecifications);
            context.SaveChanges();
        }

        public static void AddLocations(this VehifleetContext context)
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
            context.SaveChanges();
        }

        public static void AddVehicles(this VehifleetContext context, int vehicleCount = 30)
        {
            int newVehicleId = context.Vehicles
                                      .OrderByDescending(v => v.Id)
                                      .First().Id;
            newVehicleId++;
            int lastVehicleSpecificationId = context.VehicleSpecifications
                                                    .OrderByDescending(v => v.Id)
                                                    .First().Id;
            var locations = context.Locations.ToList();
            var vehicles = new List<Vehicle>();
            var insurances = new List<Insurance>();
            var inspections = new List<Inspection>();
            var platePrefix = new List<string>
            {
                "WRO",
                "OPO",
                "DWR",
                "PBK",
                "GMD"
            };

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            for (int i = 0; i < vehicleCount; i++)
            {
                StringBuilder plate = new StringBuilder();
                plate.Append($"{platePrefix[rng.Next(platePrefix.Count)]} ");
                char[] postfix = 
                {
                    chars[rng.Next(0, chars.Length)],
                    chars[rng.Next(0, chars.Length)],
                    chars[rng.Next(0, chars.Length)],
                    chars[rng.Next(0, chars.Length)],
                };
                string platePostfix = new string(postfix);
                plate.Append(platePostfix);

                StringBuilder code = new StringBuilder();
                for (int j = 0; j < 12; j++)
                {
                    code.Append(chars[rng.Next(0, chars.Length)]);
                }

                int yearOfManufacture = rng.Next(2015, 2019);
                int mileage = (2018 - yearOfManufacture) * rng.Next(3000, 7000);
                int fuelConsumed = (int) (rng.Next(40, 70) * mileage / 1000);
                decimal cost = fuelConsumed * 6;
                vehicles.Add(new Vehicle
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    VehicleSpecificationId = rng.Next(1, lastVehicleSpecificationId),
                    ChassisCode = code.ToString(),
                    LicensePlate = plate.ToString(),
                    YearOfManufacture = yearOfManufacture,
                    Status = VehicleStatus.Available,
                    Mileage = mileage,
                    FuelConsumed = fuelConsumed,
                    Cost = cost,
                    LocationCode = locations[rng.Next(0, locations.Count)].LocationCode
                });

                AddInsurances(vehicles.Last(), newVehicleId, insurances);
                AddInspections(vehicles.Last(), newVehicleId, inspections);
                newVehicleId++;
            }

            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
            context.Insurances.AddRange(insurances);
            context.Inspections.AddRange(inspections);
            context.SaveChanges();
        }

        public static void AddInsurances(Vehicle vehicle, int vehicleId, List<Insurance> insurances)
        {
            DateTime start = new DateTime(vehicle.YearOfManufacture, rng.Next(1, 12), rng.Next(1, 25));
            int mileagePart = vehicle.Mileage / (2019 - vehicle.YearOfManufacture);
            while (true)
            {
                DateTime end = start.AddYears(1);
                insurances.Add(new Insurance
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = rng.Next(600, 800),
                    StartDate = start,
                    ExpirationDate = end,
                    InsuranceId = $"FXA-{start.Year}" +
                                  $"-{start.Month}" +
                                  $"-{start.Day}" +
                                  $"-{1000 + rng.Next(0, 200) + start.Day}",
                    VehicleId = vehicleId,
                    Mileage = (start.Year * mileagePart)
                });
                if (end.Year == 2019)
                {
                    return;
                }
                else
                {
                    start = end;
                }
            }
        }

        public static void AddInspections(Vehicle vehicle, int vehicleId, List<Inspection> inspections)
        {
            DateTime start = new DateTime(vehicle.YearOfManufacture, rng.Next(1, 12), rng.Next(1, 25));
            int mileagePart = vehicle.Mileage / (2019 - vehicle.YearOfManufacture);
            while (true)
            {
                DateTime end = start.AddYears(1);
                inspections.Add(new Inspection
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = 100,
                    StartDate = start,
                    ExpirationDate = end,
                    VehicleId = vehicleId,
                    Mileage = start.Year * mileagePart,
                    Passed = true
                });
                if (end.Year == 2019)
                {
                    return;
                }
                else
                {
                    start = end;
                }
            }
        }
    }
}