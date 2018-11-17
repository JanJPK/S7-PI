using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehifleet.Data.Models.BaseEntities;

namespace Vehifleet.Helper.Extensions
{
    public static class CostGeneratingEntityExtensions
    {
        public static void AddGeneratedCosts(this CostGeneratingEntity destination, CostGeneratingEntity source)
        {
            destination.Cost += source.Cost;
            destination.FuelConsumed += source.FuelConsumed;
            destination.Mileage += source.Mileage;
        }
    }
}
