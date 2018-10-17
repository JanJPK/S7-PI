using System;
using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Model
{
    public class Insurance
    {
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string InsuranceId { get; set; }

        [Required]
        public int Mileage { get; set; }
    }
}