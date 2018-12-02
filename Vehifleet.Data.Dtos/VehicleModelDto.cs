using System.ComponentModel.DataAnnotations;
using Vehifleet.Data.Dtos.BaseDtos;

namespace Vehifleet.Data.Dtos
{
    public class VehicleModelDto : CostGeneratingDto
    {
        [Required]
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
        [MaxLength(60)]
        public string Engine { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public decimal PurchaseCost { get; set; }

        public bool HasVehicles { get; set; }
    }
}