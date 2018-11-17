using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public DateTime CanBeBookedUntil { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }

        public virtual ICollection<Insurance> Insurances { get; set; }

        public virtual ICollection<Maintenance> Maintenances { get; set; }


        //[NotMapped]
        //public Insurance CurrentInsurance => Insurances.OrderByDescending(i => i.ExpirationDate).First();

        //[NotMapped]
        //public Inspection CurrentInspection => Inspections.OrderByDescending(i => i.ExpirationDate).First();

        //[NotMapped]
        //public DateTime CanBeBookedUntil => CurrentInsurance.ExpirationDate < CurrentInspection.ExpirationDate
        //                                         ? CurrentInsurance.ExpirationDate
        //                                         : CurrentInspection.ExpirationDate;
    }
}