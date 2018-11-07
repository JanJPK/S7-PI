using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Vehifleet.Data.Models.BaseEntities;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.Models
{
    public class Vehicle : CostGeneratingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleSpecificationId { get; set; }

        public VehicleSpecification VehicleSpecification { get; set; }
        
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

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }

        public virtual ICollection<Insurance> Insurances { get; set; }

        public virtual ICollection<Maintenance> Maintenances { get; set; }

        [NotMapped]
        public DateTime CanBeBookedUntil => Insurances.Last().ExpirationDate < Inspections.Last().ExpirationDate
                                                 ? Insurances.Last().ExpirationDate
                                                 : Inspections.Last().ExpirationDate;
    }
}