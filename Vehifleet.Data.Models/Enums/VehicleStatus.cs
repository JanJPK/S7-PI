namespace Vehifleet.Data.Models.Enums
{
    public enum VehicleStatus
    {
        Available = 0,
        Unavailable = 1,
        Booked = 2 | Unavailable,
        InMaintenance = 4 | Unavailable,
        AwaitingInsuranceRenewal = 8 | Unavailable,
        AwaitingInspection = 16 | Unavailable,
        Decommissioned = 32 | Unavailable
    }
}