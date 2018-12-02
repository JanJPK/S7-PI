using System;
using Vehifleet.Data.Dtos.BaseDtos;

namespace Vehifleet.Data.Dtos
{
    /// <summary>
    ///     Describes entirety of vehicle.
    ///     Used in details, edit, add views.s
    /// </summary>
    public class VehicleDto : CostGeneratingDto
    {
        public int Id { get; set; }

        public int VehicleModelId { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Seats { get; set; }

        public int Horsepower { get; set; }

        public string Engine { get; set; }

        public string Status { get; set; }

        public string LicensePlate { get; set; }

        public int YearOfManufacture { get; set; }

        public string ChassisCode { get; set; }

        public string LocationCode { get; set; }

        public DateTime InspectionValidUntil { get; set; }

        public DateTime CanBeBookedUntil { get; set; }

        public bool HasBookings { get; set; }

    }
}