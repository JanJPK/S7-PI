using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Helper.Extensions
{
    public static class CostGeneratingEntityExtensions
    {
        public static void AddGeneratedCosts(this CostGeneratingEntity destination, CostGeneratingEntity source)
        {
            if (destination == null || source == null)
            {
                return;
            }

            destination.Cost += source.Cost;
            destination.FuelConsumed += source.FuelConsumed;
            destination.Mileage += source.Mileage;
        }
    }
}