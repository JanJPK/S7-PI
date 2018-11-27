using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Dtos.BaseDtos;

namespace Vehifleet.Data.Dtos
{
    public class MaintenanceDto : AuditableDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public bool Regular { get; set; }

        [Required]
        public bool Completed { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}