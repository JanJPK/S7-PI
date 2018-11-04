using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Maintenance : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
        
        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public bool Completed { get; set; }
    }
}