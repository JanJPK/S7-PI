using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class VehicleMaintenanceSchedule : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        public int VehicleSpecificationId { get; set; }

        public VehicleSpecification VehicleSpecification { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int MileageBetween { get; set; }
    }
}