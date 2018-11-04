using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class CostCenter : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string CostCenterCode { get; set; }
    }
}