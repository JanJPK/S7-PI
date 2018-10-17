using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Model.Enums;

namespace Vehifleet.Model
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public VehicleSpecification VehicleSpecification { get; set; }

        public Booking Booking { get; set; }

        [Required]
        public int UsageReportId { get; set; }
        
        public UsageReport UsageReport { get; set; }

        [Required]
        public VehicleStatus Status { get; set; }

        [Required]
        [MaxLength(20)]
        public string LicensePlate { get; set; }

        public DateTime InspectionExpirationDate { get; set; }

        public DateTime InsuranceExpirationDate { get; set; }
    }
}