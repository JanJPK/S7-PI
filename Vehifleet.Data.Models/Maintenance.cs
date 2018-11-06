using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Maintenance : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        
        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Distance { get; set; }

        [Required]
        public bool Completed { get; set; }
    }
}