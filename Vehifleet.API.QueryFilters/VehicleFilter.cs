﻿using System;
using System.Collections.Generic;
using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API.QueryFilters
{
    public class VehicleFilter : IQueryFilter<Vehicle>
    {
        public IEnumerable<string> Manufacturer { get; set; }

        public IEnumerable<string> Model { get; set; }

        public IEnumerable<string> LocationCode { get; set; }

        public int? MinBookingDays { get; set; }

        public string Status { get; set; }

        public IQueryable<Vehicle> Filter(IQueryable<Vehicle> query)
        {
            if (Manufacturer.NotNullOrEmpty())
            {
                query = query.Where(v => Manufacturer.Any(m => m == v.VehicleModel.Manufacturer));
            }

            if (Model.NotNullOrEmpty())
            {
                query = query.Where(v => Model.Any(m => m == v.VehicleModel.Model));
            }

            if (LocationCode.NotNullOrEmpty())
            {
                query = query.Where(v => LocationCode.Any(l => l == v.LocationCode));
            }

            if (MinBookingDays == null && MinBookingDays > 0)
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
