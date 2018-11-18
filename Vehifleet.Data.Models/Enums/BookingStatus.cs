namespace Vehifleet.Data.Models.Enums
{
    /// <summary>
    ///     States of booking.
    /// </summary>
    public enum BookingStatus
    {
        Created = 0,
        Submitted = 1,
        NeedsAdjustment = 2,
        Rejected = 3,
        Accepted = 4,
        AwaitingReview = 5,
        Completed = 6        
    }
}