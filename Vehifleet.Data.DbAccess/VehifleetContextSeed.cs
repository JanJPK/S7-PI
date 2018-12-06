using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.Data.DbAccess
{
    /// <summary>
    ///     Ugly static class to seed database with data that more or less makes sense.
    /// </summary>
    public static class VehifleetContextSeed
    {
        #region Static data

        private static readonly Random Rng = new Random();

        private static readonly List<string> Insurers = new List<string>
        {
            "Protecto",
            "AutoAssistance",
            "Goldberg Insurance"
        };

        private static readonly List<string> PlatePrefixes = new List<string>
        {
            "WRO",
            "OPO",
            "DWR",
            "PBK",
            "GMD"
        };

        private static readonly char[] AllowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        #endregion

        public static void AddVehicleModels(this VehifleetContext context)
        {
            var vehicleModels = new List<VehicleModel>
            {
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "Focus",
                    ConfigurationCode = "FF2018184",
                    Horsepower = 115,
                    Seats = 4,
                    Weight = 1200,
                    Engine = "1.8 TDCi",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 70000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "Focus",
                    ConfigurationCode = "FF2018154",
                    Horsepower = 85,
                    Seats = 4,
                    Weight = 1150,
                    Engine = "1.2 Eco",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 60000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "Mondeo",
                    ConfigurationCode = "FM2018184",
                    Horsepower = 155,
                    Seats = 4,
                    Weight = 1300,
                    Engine = "1.8 EcoBoost",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 120000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Toyota",
                    Model = "Auris",
                    ConfigurationCode = "TA2018174",
                    Horsepower = 115,
                    Seats = 4,
                    Weight = 1300,
                    Engine = "1.6 6A-GMD",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 64000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Toyota",
                    Model = "Corolla",
                    ConfigurationCode = "TC2018144",
                    Horsepower = 90,
                    Seats = 4,
                    Weight = 1270,
                    Engine = "1.0 4A-GAE",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 55000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "C-Max",
                    ConfigurationCode = "FC2014184",
                    Horsepower = 105,
                    Seats = 5,
                    Weight = 1300,
                    Engine = "1.6 TDDi",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 73000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Ford",
                    Model = "S-Max",
                    ConfigurationCode = "FS2012184",
                    Horsepower = 105,
                    Seats = 6,
                    Weight = 1400,
                    Engine = "1.6 TDDi",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 79000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Skoda",
                    Model = "Superb",
                    ConfigurationCode = "SS185184",
                    Horsepower = 185,
                    Seats = 4,
                    Weight = 1200,
                    Engine = "1.8 SKT-D3TT",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 112000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Skoda",
                    Model = "Octavia",
                    ConfigurationCode = "SO14184",
                    Horsepower = 140,
                    Seats = 4,
                    Weight = 1250,
                    Engine = "1.8 SKT-D2",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 68000
                },
                new VehicleModel
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Manufacturer = "Skoda",
                    Model = "Rapid",
                    ConfigurationCode = "SR14184",
                    Horsepower = 90,
                    Seats = 4,
                    Weight = 1100,
                    Engine = "1.4 SKT-D1",
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0,
                    PurchaseCost = 67000
                },
            };
            context.VehicleModels.AddRange(vehicleModels);
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
                    LocationName = "Grey Towers"
                },
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Świerkowa 21",
                    City = "Wrocław",
                    LocationCode = "WRO-2",
                    LocationName = "GMD Building"
                },
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Smogowa 96",
                    City = "Kraków",
                    LocationCode = "KRK-1",
                    LocationName = "Smog Center"
                },
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Lipowa 88",
                    City = "Wrocław",
                    LocationCode = "WRO-3",
                    LocationName = "Exquisite Center"
                },
                new Location
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Address = "Garncarska 4",
                    City = "Opole",
                    LocationCode = "OPO-1",
                    LocationName = "Golden Tower"
                }
            };
            context.Locations.AddRange(locations);
            context.SaveChanges();
        }

        public static void AddRoles(this VehifleetContext context)
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }

        public static void AddUsers(this VehifleetContext context)
        {
        }

        #region Vehicle seeding

        public static string GeneratePlate()
        {
            StringBuilder plate = new StringBuilder();
            plate.Append($"{PlatePrefixes[Rng.Next(PlatePrefixes.Count)]} ");
            char[] postfix =
            {
                AllowedChars[Rng.Next(0, AllowedChars.Length)],
                AllowedChars[Rng.Next(0, AllowedChars.Length)],
                AllowedChars[Rng.Next(0, AllowedChars.Length)],
                AllowedChars[Rng.Next(0, AllowedChars.Length)],
            };

            string platePostfix = new string(postfix);
            plate.Append(platePostfix);
            return plate.ToString();
        }

        public static string GenerateChassisCode()
        {
            StringBuilder code = new StringBuilder();
            for (int j = 0; j < 12; j++)
            {
                code.Append(AllowedChars[Rng.Next(0, AllowedChars.Length)]);
            }

            return code.ToString();
        }

        public static Vehicle GenerateVehicle(this VehifleetContext context)
        {
            var locations = context.Locations.ToList();
            var vehicleModels = context.VehicleModels.OrderBy(vm => vm.Id).ToList();

            var plate = GeneratePlate();
            var code = GenerateChassisCode();
            int yearOfManufacture = Rng.Next(2015, 2019);
            int mileage = (2018 - yearOfManufacture) * Rng.Next(3000, 7000);
            int fuelConsumed = Rng.Next(40, 70) * mileage / 1000;
            decimal cost = fuelConsumed * 3;

            var vehicle = new Vehicle
            {
                AddedBy = "admin",
                AddedOn = DateTime.UtcNow,
                VehicleModelId = Rng.Next(vehicleModels.First().Id, vehicleModels.Last().Id + 1),
                ChassisCode = code,
                LicensePlate = plate,
                YearOfManufacture = yearOfManufacture,
                Status = VehicleStatus.Available,
                Mileage = mileage,
                FuelConsumed = fuelConsumed,
                Cost = cost,
                LocationCode = locations[Rng.Next(0, locations.Count)].LocationCode,
                InspectionValidUntil = new DateTime(2019, Rng.Next(1, 11), Rng.Next(1, 20))
            };

            return vehicle;
        }

        public static List<Insurance> GenerateInsurances(Vehicle vehicle)
        {
            List<Insurance> insurances = new List<Insurance>();
            DateTime start = new DateTime(vehicle.YearOfManufacture, Rng.Next(1, 12), Rng.Next(1, 25));
            int mileagePart = vehicle.Mileage / (2019 - vehicle.YearOfManufacture);

            while (true)
            {
                DateTime end = start.AddYears(1);
                int cost = Rng.Next(600, 800);

                var insurance = new Insurance
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = cost,
                    StartDate = start,
                    EndDate = end,
                    Insurer = Insurers[Rng.Next(0, Insurers.Count)],
                    InsuranceId = $"INS-{start.Year}" +
                                  $"-{start.Month}" +
                                  $"-{start.Day}" +
                                  $"-{1000 + Rng.Next(0, 200) + start.Day}",
                    VehicleId = vehicle.Id,
                    Mileage = start.Year * mileagePart
                };

                insurances.Add(insurance);
                vehicle.Cost += insurance.Cost;
                if (end.Year == 2019)
                {
                    return insurances;
                }
                else
                {
                    start = end;
                }
            }
        }

        public static List<Maintenance> GenerateMaintenances(Vehicle vehicle)
        {
            List<Maintenance> maintenances = new List<Maintenance>();
            int maintenanceCount = Rng.Next(1, 2019 - vehicle.YearOfManufacture + 3);
            int mileagePart = vehicle.Mileage / (2019 - vehicle.YearOfManufacture);
            for (int i = 0; i < maintenanceCount; i++)
            {
                DateTime start = new DateTime(Rng.Next(vehicle.YearOfManufacture, 2019), Rng.Next(1, 10), Rng.Next(1, 25));
                var maintenance = new Maintenance
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Completed = true,
                    Description = "Maintenance example generated during seeding.",
                    Cost = Rng.Next(200, 2000),
                    StartDate = start,
                    EndDate = start.AddDays(Rng.Next(3, 15)),
                    Mileage = start.Year * mileagePart,
                    Regular = Rng.Next() % 2 == 1,
                    VehicleId = vehicle.Id
                };

                maintenances.Add(maintenance);
                vehicle.Cost += maintenance.Cost;
            }

            return maintenances;
        }

        public static List<Booking> GenerateBookings(this VehifleetContext context, Vehicle vehicle)
        {
            var employees = context.Employees.ToList();
            int bookingsCount = Rng.Next(1, 2019 - vehicle.YearOfManufacture + 15);
            List<Booking> bookings = new List<Booking>();
            for (int i = 0; i < bookingsCount; i++)
            {
                DateTime start = new DateTime(Rng.Next(vehicle.YearOfManufacture, 2019), Rng.Next(1, 10), Rng.Next(1, 25));
                var employee = employees[Rng.Next(0, employees.Count)];
                var mileage = Rng.Next(0, 200);
                var fuelConsumed = (int) (mileage * 6 / 100);

                var booking = new Booking
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    EmployeeId = employee.Id,
                    Status = BookingStatus.Completed,
                    Mileage = mileage,
                    FuelConsumed = fuelConsumed,
                    Cost = fuelConsumed * 4,
                    Purpose = "Example purpose generated during seeding.",
                    StartDate = start,
                    EndDate = start.AddDays(Rng.Next(3, 15)),
                    VehicleId = vehicle.Id
                };
                vehicle.AddGeneratedCosts(booking);
                vehicle.VehicleModel.AddGeneratedCosts(booking);
                employee.AddGeneratedCosts(booking);
                bookings.Add(booking);
            }

            return bookings;
        }

        public static void AddVehicles(this VehifleetContext context, int vehicleCount = 50)
        {
            for (int i = 0; i < vehicleCount; i++)
            {
                context.Vehicles.Add(GenerateVehicle(context));
            }
            
            if (!context.Vehicles.Any())
            {
                context.SaveChanges();
            }
            
            foreach (var vehicle in context.Vehicles.Include(v => v.VehicleModel).ToList())
            {
                context.Insurances.AddRange(GenerateInsurances(vehicle));
                context.Bookings.AddRange(GenerateBookings(context, vehicle));
                if (vehicle.Mileage > 0)
                {
                    context.Maintenances.AddRange(GenerateMaintenances(vehicle));
                }
            }
            

            context.SaveChanges();
        }

        public static void AdjustVehicleCanBeBookedUntil(this VehifleetContext context)
        {
            foreach (var vehicle in context.Vehicles.Include(v => v.Insurances).ToList())
            {
                if (vehicle.Insurances.Any())
                {
                    var mostRecentInsurance = vehicle.Insurances.OrderBy(i => i.EndDate).Last().EndDate;
                    vehicle.CanBeBookedUntil = mostRecentInsurance < vehicle.InspectionValidUntil
                                                   ? mostRecentInsurance
                                                   : vehicle.InspectionValidUntil;
                    context.Vehicles.Update(vehicle);
                }
            }

            context.SaveChanges();
        }

        #endregion
    }
}