using System;
using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Model
{
    public class Maintenance
    {
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Mileage { get; set; }
    }
}