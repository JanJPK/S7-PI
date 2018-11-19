using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    /// <summary>
    ///     Insurance of a vehicle.
    /// </summary>
    public class Insurance : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Cost { get; set; }

        [Required]
        [MaxLength(50)]
        public string Insurer { get; set; }

        [Required]
        public string InsuranceId { get; set; }

        [Required]
        public int Mileage { get; set; }
    }
}