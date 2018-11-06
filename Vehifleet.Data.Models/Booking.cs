using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vehifleet.Data.Models.BaseEntities;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.Models
{
    public class Booking : CostGeneratingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        // Booking <-> Employee relationship is configured in Context class.
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int? ManagerId { get; set; }

        public virtual Employee Manager { get; set; }

        [Required]
        public BookingStatus Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Notes { get; set; }
    }
}