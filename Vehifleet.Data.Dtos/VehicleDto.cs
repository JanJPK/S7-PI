﻿using System;
using Vehifleet.Data.Models;

namespace Vehifleet.Data.Dtos
{
    /// <summary>
    ///     Describes entirety of vehicle.
    ///     Used in details, edit, add views.s
    /// </summary>
    public class VehicleDto
    {
        public int Id { get; set; }        

        public VehicleModel VehicleModel { get; set; }

        public string Status { get; set; }

        public string LicensePlate { get; set; }

        public int YearOfManufacture { get; set; }

        public string ChassisCode { get; set; }

        public string LocationCode { get; set; }

        public int Mileage { get; set; }
        
        public DateTime CanBeBookedUntil { get; set; }
    }
}