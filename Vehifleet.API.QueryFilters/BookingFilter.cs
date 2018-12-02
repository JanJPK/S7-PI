using System;
using System.Collections.Generic;
using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API.QueryFilters
{
    public class BookingFilter : IQueryFilter<Booking>
    {
        public int? EmployeeId { get; set; }

        public int? VehicleId { get; set; }

        public IEnumerable<BookingStatus> Statuses { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string EmployeeUserName { get; set; }

        public IQueryable<Booking> Filter(IQueryable<Booking> query)
        {
            if (EmployeeId.NotNullOrLessThanOne())
            {
                query = query.Where(b => b.EmployeeId == EmployeeId);
            }

            if (VehicleId.NotNullOrLessThanOne())
            {
                query = query.Where(b => b.VehicleId == VehicleId);
            }            

            if (Statuses != null)
            {
                query = query.Where(b => Statuses.Any(s => s == b.Status));
            }

            if (FromDate != null)
            {
                query = query.Where(b => b.StartDate > FromDate);
            }

            if (ToDate != null)
            {
                query = query.Where(b => b.EndDate < ToDate);
            }

            if (EmployeeUserName.NotNullOrEmpty())
            {
                query = query.Where(b => b.Employee.Identity.UserName == EmployeeUserName);
            }

            return query;
        }
    }
}