using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Data.Models.BaseEntities
{
    public class CostGeneratingEntity : AuditableEntity
    {
        [Required]
        public int Mileage { get; set; }

        [Required]
        public decimal FuelConsumed { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}