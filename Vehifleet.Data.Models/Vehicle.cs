using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vehifleet.Data.Models.BaseEntities;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.Models
{
    /// <summary>
    ///     Data relevant to specific instance of a vehicle.
    /// </summary>
    public class Vehicle : CostGeneratingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleModelId { get; set; }

        public VehicleModel VehicleModel { get; set; }

        [ForeignKey("Location")]
        public string LocationCode { get; set; }

        public Location Location { get; set; }

        [Required]
        public VehicleStatus Status { get; set; }

        [Required]
        [MaxLength(20)]
        public string LicensePlate { get; set; }

        [Required]
        public int YearOfManufacture { get; set; }

        [Required]
        public string ChassisCode { get; set; }

        public DateTime InspectionValidUntil { get; set; }

        public DateTime CanBeBookedUntil { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Insurance> Insurances { get; set; }

        public virtual ICollection<Maintenance> Maintenances { get; set; }

        public void AdjustCanBeBookedUntil(DateTime date)
        {
            if (date < CanBeBookedUntil)
            {
                CanBeBookedUntil = date;
            }
        }
    }
}