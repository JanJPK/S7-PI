using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Inspection : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public string Notes { get; set; }

        [Required]
        public bool Passed { get; set; }

        [Required]
        public int Mileage { get; set; }
    }
}