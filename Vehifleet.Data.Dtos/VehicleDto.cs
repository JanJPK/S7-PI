using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Data.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        public int VehicleSpecificationId { get; set; }

        public string VehicleName { get; set; }

        public string LocationCode { get; set; }

        public string Status { get; set; }

        public string LicensePlate { get; set; }

        public int YearOfManufacture { get; set; }

        public string ChassisCode { get; set; }
    }
}