using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Employee : CostGeneratingEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

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