using System;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Dtos.BaseDtos;

namespace Vehifleet.Data.Dtos
{
    public class BookingDto : CostGeneratingDto
    {
        public int? Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Purpose { get; set; }

        public string Notes { get; set; }
    }
}