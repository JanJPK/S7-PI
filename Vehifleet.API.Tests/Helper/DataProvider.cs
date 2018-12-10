using System;
using System.Collections.Generic;
using Vehifleet.Data.Models;

namespace Vehifleet.API.Tests.Helper
{
    public static class DataProvider
    {
        public static IEnumerable<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 1,
                    InspectionValidUntil = new DateTime(),
                    VehicleModel = new VehicleModel
                    {
                        Id = 1,
                        Manufacturer = "Ford",
                        Model = "Mondeo"
                    },
                    Location = new Location
                    {
                        LocationCode = "1"
                    }
                },
                new Vehicle
                {
                    Id = 2,
                    InspectionValidUntil = new DateTime(),
                    VehicleModel = new VehicleModel
                    {
                        Id = 2,
                        Manufacturer = "Ford",
                        Model = "Focus"
                    },
                    Location = new Location
                    {
                        LocationCode = "1"
                    }
                },
                new Vehicle
                {
                    Id = 3,
                    InspectionValidUntil = new DateTime(),
                    VehicleModel = new VehicleModel
                    {
                        Id = 3,
                        Manufacturer = "Toyota",
                        Model = "Auris"
                    },
                    Location = new Location
                    {
                        LocationCode = "2"
                    }
                }
            };
        }

        public static IEnumerable<VehicleModel> GetVehicleModels()
        {
            return new List<VehicleModel>
            {
                new VehicleModel
                {
                    Id = 1,
                    Manufacturer = "Ford",
                    Model = "Mondeo"
                },
                new VehicleModel
                {
                    Id = 2,
                    Manufacturer = "Ford",
                    Model = "Focus"
                },
                new VehicleModel
                {
                    Id = 3,
                    Manufacturer = "Toyota",
                    Model = "Auris"
                },
            };
        }
    }
}