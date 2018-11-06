using System;
using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Data.Models.BaseEntities
{
    public class AuditableEntity
    {
        [Required]
        public DateTime AddedOn { get; set; }

        [Required]
        public string AddedBy { get; set; }
            
        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}