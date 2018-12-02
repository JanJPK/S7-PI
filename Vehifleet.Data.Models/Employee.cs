using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    /// <summary>
    ///     Employee data related to business logic only.
    /// </summary>
    public class Employee : CostGeneratingEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EmployeeIdentity")]
        public string IdentityId { get; set; }

        public virtual EmployeeIdentity Identity { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        [NotMapped]
        public string Jwt { get; set; }
    }
}