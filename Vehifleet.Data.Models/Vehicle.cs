using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.Models
{
    public class Vehicle : CostGeneratingEntity
    {
        public int Id { get; set; }

        [Required]
        public VehicleSpecification VehicleSpecification { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }

        [Required]
        public VehicleStatus Status { get; set; }

        [Required]
        [MaxLength(20)]
        public string LicensePlate { get; set; }

        [Required]
        public int YearOfManufacture { get; set; }

        [Required]
        public string ChassisCode { get; set; }
    }
}