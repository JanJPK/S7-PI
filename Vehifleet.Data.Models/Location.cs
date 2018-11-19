using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class Location : AuditableEntity
    {
        [Key]
        public string LocationCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string LocationName { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength(40)]
        public string Address { get; set; }
    }
}