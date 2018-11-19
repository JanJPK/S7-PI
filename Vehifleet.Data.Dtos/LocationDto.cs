using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Data.Dtos
{
    public class LocationDto
    {
        [Required]
        public string LocationCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string LocationName { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength(40)]
        public string Address { get; set; }
    }
}
