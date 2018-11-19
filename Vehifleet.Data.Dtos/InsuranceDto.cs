using System;
using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Data.Dtos
{
    public class InsuranceDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
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