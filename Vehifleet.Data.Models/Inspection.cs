using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Inspection : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Cost { get; set; }

        public string Notes { get; set; }

        [Required]
        public bool Passed { get; set; }

        [Required]
        public int Mileage { get; set; }
    }
}