using System;

namespace Vehifleet.Data.Dtos
{
    public class VehicleListItemDto
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Horsepower { get; set; }

        public int Seats { get; set; }

        public int YearOfManufacture { get; set; }

        public string LocationCode { get; set; }

        public DateTime? CanBeBookedUntil { get; set; }

        public string Status { get; set; }

        public string ChassisCode { get; set; }
    }
}