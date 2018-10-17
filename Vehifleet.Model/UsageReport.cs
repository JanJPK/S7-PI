using System;
using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Model
{
    public class UsageReport
    {
        public int Id { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public decimal FuelConsumed { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public DateTime Date { get; set; }
    }
}