using System;
using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.API.QueryFilters
{
    public class VehicleFilter : IQueryFilter<Vehicle>
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string LocationCode { get; set; }

        public int MinBookingDays { get; set; }

        public string Status { get; set; }

        public IQueryable<Vehicle> Filter(IQueryable<Vehicle> query)
        {
            if (!string.IsNullOrEmpty(Manufacturer))
            {
                query = query.Where(v => v.VehicleSpecification.Manufacturer == Manufacturer);
            }

            if (!string.IsNullOrEmpty(Model))
            {
                query = query.Where(v => v.VehicleSpecification.Model == Model);
            }

            if (!string.IsNullOrEmpty(LocationCode))
            {
                query = query.Where(v => v.LocationCode == LocationCode);
            }

            if (MinBookingDays > 0)
            {
                query = query.Where(v => (v.CanBeBookedUntil - DateTime.UtcNow).Days > MinBookingDays);
            }

            if (Enum.TryParse(Status, out VehicleStatus status))
            {
                query = query.Where(v => v.Status == status);
            }

            return query;
        }
    }
}
