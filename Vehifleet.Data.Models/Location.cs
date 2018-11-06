using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Location : AuditableEntity
    {
        [Key]
        public string LocationCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}