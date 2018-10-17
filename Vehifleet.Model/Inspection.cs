using System;
using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Model
{
    public class Inspection
    {
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public string Notes { get; set; }

        [Required]
        public bool Passed { get; set; }

        [Required]
        public int Mileage { get; set; }
    }
}