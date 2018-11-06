using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Employee : CostGeneratingEntity
    {
        [Key]
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
        public bool IsActive { get; set; }

        public string Role { get; set; }

        [Required]
        public string Department { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Booking> ManagedBookings { get; set; }
    }
}