using Vehifleet.Data.Models.BaseEntities;
using Vehifleet.Helper.Extensions;
using Xunit;

namespace Vehifleet.Helper.Tests
{
    public class CostGeneratingEntityExtensionsTests
    {
        [Fact]
        public void Should_Add_Costs()
        {
            // Arrange
            int difference = 100;
            var source = new CostGeneratingEntity
            {
                Cost = difference,
                FuelConsumed = difference,
                Mileage = difference
            };
            var destination = new CostGeneratingEntity
            {
                Cost = 0,
                FuelConsumed = 0,
                Mileage = 0
            };

            // Act
            destination.AddGeneratedCosts(source);

            // Assert
            Assert.True(destination.Cost == difference);
            Assert.True(destination.FuelConsumed == difference);
            Assert.True(destination.Mileage == difference);
        }

        [Fact]
        public void Should_Subtract_Costs()
        {
            // Arrange
            int difference = -100;
            var source = new CostGeneratingEntity
            {
                Cost = difference,
                FuelConsumed = difference,
                Mileage = difference
            };
            var destination = new CostGeneratingEntity
            {
                Cost = 0,
                FuelConsumed = 0,
                Mileage = 0
            };

            // Act
            destination.AddGeneratedCosts(source);

            // Assert
            Assert.True(destination.Cost == difference);
            Assert.True(destination.FuelConsumed == difference);
            Assert.True(destination.Mileage == difference);
        }

        [Fact]
        public void Should_Handle_Null_Source()
        {
            // Arrange            
            var destination = new CostGeneratingEntity
            {
                Cost = 0,
                FuelConsumed = 0,
                Mileage = 0
            };

            // Act
            var ex = Record.Exception(() => { destination.AddGeneratedCosts(null); });

            // Assert
            Assert.Null(ex);
        }
    }
}