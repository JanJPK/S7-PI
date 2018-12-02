using System;
using System.Collections.Generic;
using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API.QueryFilters
{
    public class VehicleFilter : IQueryFilter<Vehicle>
    {
        public string Manufacturer { get; set; }

        public int? VehicleModelId { get; set; }

        public string LocationCode { get; set; }

        public string ChassisCode { get; set; }

        public int? MinBookingDays { get; set; }

        public string Status { get; set; }

        public IQueryable<Vehicle> Filter(IQueryable<Vehicle> query)
        {
            //if (Manufacturer.NotNullOrEmpty())
            //{
            //    query = query.Where(v => Manufacturer.Any(m => m == v.VehicleModel.Manufacturer));
            //}

            if (Manufacturer.NotNullOrEmpty())
            {                
                query = query.Where(v => v.VehicleModel.Manufacturer == Manufacturer);
            }

            if (VehicleModelId.NotNullOrLessThanOne())
            {
                query = query.Where(v => v.VehicleModel.Id == VehicleModelId);
            }

            if (LocationCode.NotNullOrEmpty())
            {
                query = query.Where(v => v.LocationCode == LocationCode);
            }

            if (ChassisCode.NotNullOrEmpty())
            {
                query = query.Where(v => v.ChassisCode == ChassisCode);
            }

            if (MinBookingDays != null && MinBookingDays > 0)
            {
                query = query.Where(v => (v.InspectionValidUntil - DateTime.UtcNow).Days > MinBookingDays);
            }

            if (Enum.TryParse(Status, out VehicleStatus status))
            {
                query = query.Where(v => v.Status == status);
            }

            return query;
        }
    }
}
