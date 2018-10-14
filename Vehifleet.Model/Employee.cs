using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserId { get; set; }

        [Required]
        public bool IsManager { get; set; }

        [Required]
        public int CostCenterId { get; set; }

        public CostCenter CostCenter { get; set; }

        public int? BookingId { get; set; }

        public Booking Booking { get; set; }

        [Required]
        public bool UsageReport { get; set; }
    }
}