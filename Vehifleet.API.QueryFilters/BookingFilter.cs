using System;
using System.Linq;
using Vehifleet.Data.Models;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Helper.Extensions;

namespace Vehifleet.API.QueryFilters
{
    public class BookingFilter : IQueryFilter<Booking>
    {
        public int? EmployeeId { get; set; }

        public int? ManagerId { get; set; }

        public int? VehicleId { get; set; }

        public BookingStatus? Status { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public IQueryable<Booking> Filter(IQueryable<Booking> query)
        {
            if (EmployeeId.NotNullOrLessThanOne())
            {
                query = query.Where(b => b.EmployeeId == EmployeeId);
            }

            if (ManagerId.NotNullOrLessThanOne())
            {
                query = query.Where(b => b.ManagerId == ManagerId);
            }

            if (VehicleId.NotNullOrLessThanOne())
            {
                query = query.Where(b => b.VehicleId == VehicleId);
            }

            if (Status != null)
            {
                query = query.Where(b => b.Status == Status);
            }

            if (FromDate != null)
            {
                query = query.Where(b => b.StartDate < FromDate);
            }

            if (ToDate != null)
            {
                query = query.Where(b => b.EndDate < ToDate);
            }

            return query;
        }
    }
}