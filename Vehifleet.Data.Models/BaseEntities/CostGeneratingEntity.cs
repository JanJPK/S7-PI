using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vehifleet.Data.Models.BaseEntities
{
    public class CostGeneratingEntity : AuditableEntity
    {
        [Required]
        public int Mileage { get; set; }

        [Required]
        public int FuelConsumed { get; set; }

        [Required]
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Cost { get; set; }
    }
}