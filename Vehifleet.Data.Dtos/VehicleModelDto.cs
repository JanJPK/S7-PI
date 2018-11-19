using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehifleet.Data.Models;

namespace Vehifleet.Data.Dtos
{
    public class VehicleModelDto
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
        
    }
}
