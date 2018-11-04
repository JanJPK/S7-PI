using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    public class VehicleSpecification : CostGeneratingEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }

        [Required]
        [MaxLength(50)]
        public string ConfigurationCode { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public decimal Weight { get; set; }
    }
}