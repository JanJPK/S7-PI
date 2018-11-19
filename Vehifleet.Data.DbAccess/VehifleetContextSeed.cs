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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
                },
                new VehicleModel
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
                    Cost = 0
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
                    Mileage = 0,
                    FuelConsumed = 0,
                    Cost = 0
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

        public static void AddVehicles(this VehifleetContext context, int vehicleCount = 30)
        {
            int newVehicleId = context.Vehicles
                                      .OrderByDescending(v => v.Id)
                                      .First().Id;
            newVehicleId++;
            int lastVehicleSpecificationId = context.VehicleModels
                                                    .OrderByDescending(v => v.Id)
                                                    .First().Id;
            var locations = context.Locations.ToList();
            var vehicles = new List<Vehicle>();
            var insurances = new List<Insurance>();

            for (int i = 0; i < vehicleCount; i++)
            {
                var plate = GeneratePlate();
                var code = GenerateChassisCode();
                int yearOfManufacture = Rng.Next(2015, 2019);
                int mileage = (2018 - yearOfManufacture) * Rng.Next(3000, 7000);
                int fuelConsumed = (int) (Rng.Next(40, 70) * mileage / 1000);
                decimal cost = fuelConsumed * 6;
                vehicles.Add(new Vehicle
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    VehicleModelId = Rng.Next(1, lastVehicleSpecificationId),
                    ChassisCode = code,
                    LicensePlate = plate,
                    YearOfManufacture = yearOfManufacture,
                    Status = VehicleStatus.Available,
                    Mileage = mileage,
                    FuelConsumed = fuelConsumed,
                    Cost = cost,
                    LocationCode = locations[Rng.Next(0, locations.Count)].LocationCode,
                    InspectionValidUntil = new DateTime(2019, Rng.Next(0, 12), Rng.Next(0, 20))
                });

                AddInsurances(vehicles.Last(), newVehicleId, insurances);
                newVehicleId++;
            }

            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
            context.Insurances.AddRange(insurances);
            context.SaveChanges();
        }

        public static void AddInsurances(Vehicle vehicle, int vehicleId, List<Insurance> insurances)
        {
            DateTime start = new DateTime(vehicle.YearOfManufacture, Rng.Next(1, 12), Rng.Next(1, 25));
            int mileagePart = vehicle.Mileage / (2019 - vehicle.YearOfManufacture);
            while (true)
            {
                DateTime end = start.AddYears(1);
                insurances.Add(new Insurance
                {
                    AddedBy = "admin",
                    AddedOn = DateTime.UtcNow,
                    Cost = Rng.Next(600, 800),
                    StartDate = start,
                    EndDate = end,
                    Insurer = Insurers[Rng.Next(0, Insurers.Count)],
                    InsuranceId = $"INS-{start.Year}" +
                                  $"-{start.Month}" +
                                  $"-{start.Day}" +
                                  $"-{1000 + Rng.Next(0, 200) + start.Day}",
                    VehicleId = vehicleId,
                    Mileage = start.Year * mileagePart
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

        #endregion
    }
}