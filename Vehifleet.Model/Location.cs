using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Model
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string LocationCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }
    }
}