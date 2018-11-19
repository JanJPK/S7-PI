using System;
using System.Collections.Generic;
using System.Linq;
using Vehifleet.Data.Models.Enums;
using Vehifleet.Helper.Extensions;
using Vehifleet.Services.Interfaces;

namespace Vehifleet.Services
{
    /// <summary>
    ///     Vehicle and booking service.
    /// </summary>
    public class StatusService : IStatusService
    {
        /// Describes allowed status transitions.
        /// Key is the source status, value is array of allowed statuses it can change to.
        private static readonly Dictionary<BookingStatus, BookingStatus[]> BookingStatusTransitions =
            new Dictionary<BookingStatus, BookingStatus[]>
            {
                {BookingStatus.Created, new[] {BookingStatus.Submitted}},
                {
                    BookingStatus.Submitted,
                    new[] {BookingStatus.Accepted, BookingStatus.Rejected}
                },                
                {BookingStatus.Rejected, null},
                {BookingStatus.Accepted, new[] {BookingStatus.Completed}}
            };

        public IEnumerable<BookingStatus> GetBookingStatuses()
        {
            return Enum.GetValues(typeof(BookingStatus)).Cast<BookingStatus>();
        }

        public IEnumerable<VehicleStatus> GetVehicleStatuses()
        {
            return Enum.GetValues(typeof(VehicleStatus)).Cast<VehicleStatus>();
        }

        public bool VerifyBookingStatusTransition(BookingStatus source, BookingStatus destination)
        {
            if (BookingStatusTransitions[source].NotNullOrEmpty())
            {
                return BookingStatusTransitions[source].Contains(destination);
            }
            else
            {
                return false;
            }
        }
    }
}