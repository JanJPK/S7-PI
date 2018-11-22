using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Data.Models
{
    /// <summary>
    ///     Vehicle technical specifications.
    /// </summary>
    public class VehicleModel : CostGeneratingEntity
    {
        [Key]
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
        [Column(TypeName = "decimal(16, 2)")]
        public decimal PurchaseCost { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set;  }

        [NotMapped]
        public string Name => $"{Manufacturer} {Model}";
    }
}