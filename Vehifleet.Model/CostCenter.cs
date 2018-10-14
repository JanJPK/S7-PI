using System.ComponentModel.DataAnnotations;

namespace Vehifleet.Model
{
    public class CostCenter
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string CostCenterCode { get; set; }
    }
}