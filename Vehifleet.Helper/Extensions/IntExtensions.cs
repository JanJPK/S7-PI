namespace Vehifleet.Helper.Extensions
{
    public static class IntExtensions
    {
        public static bool NotNullOrLessThanOne(this int? number)
        {
            return number != null && number > 0;
        }

    }
}