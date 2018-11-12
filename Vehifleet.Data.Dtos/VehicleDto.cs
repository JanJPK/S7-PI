using System;

namespace Vehifleet.Data.Dtos
{
    /// <summary>
    ///     Describes entirety of vehicle.
    ///     Used in details, edit, add views.s
    /// </summary>
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

        public int Horsepower { get; set; }
        public int Seats { get; set; }

        public DateTime? InsuranceExpirationDate { get; set; }

        public DateTime? InspectionExpirationDate { get; set; }
    }
}