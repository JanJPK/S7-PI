using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Model
{
    public class VehicleMaintenanceSchedule
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