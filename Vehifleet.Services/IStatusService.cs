using System.Collections.Generic;
using Vehifleet.Data.Models.Enums;

namespace Vehifleet.Services.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<BookingStatus> GetBookingStatuses();
        IEnumerable<VehicleStatus> GetVehicleStatuses();
        bool VerifyBookingStatusTransition(BookingStatus source, BookingStatus destination);
    }
}