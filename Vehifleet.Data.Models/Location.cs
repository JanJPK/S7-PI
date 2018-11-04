using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Location : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string LocationCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }
    }
}