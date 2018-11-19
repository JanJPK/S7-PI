using System;
using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Data.Dtos
{
    public class BookingDto
    {
        public int? Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public int? ManagerId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Purpose { get; set; }

        public string Notes { get; set; }

        public int? Mileage { get; set; }

        public int? FuelConsumed { get; set; }

        public decimal? Cost { get; set; }
    }
}