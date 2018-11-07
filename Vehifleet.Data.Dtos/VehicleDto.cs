using System;

namespace Vehifleet.Data.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        public int VehicleSpecificationId { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Status { get; set; }

        public string LicensePlate { get; set; }

        public int YearOfManufacture { get; set; }

        public string ChassisCode { get; set; }

        public string LocationCode { get; set; }

        public int Mileage { get; set; }

        public DateTime? InsuranceExpirationDate { get; set; }

        public DateTime? InspectionExpirationDate { get; set; }
    }
}