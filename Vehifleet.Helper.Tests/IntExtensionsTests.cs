using Vehifleet.Helper.Extensions;
using Xunit;

namespace Vehifleet.Helper.Tests
{
    public class IntExtensionsTests
    {
        [Fact]
        public void Should_Return_True_For_Greater_Than_Zero()
        {
            // Arrange
            int? integer = 1;

            // Act
            bool isNotIntegerNullOrLessThanOne = integer.NotNullOrLessThanOne();

            // Assert
            Assert.True(isNotIntegerNullOrLessThanOne);
        }

        [Fact]
        public void Should_Return_False_For_Null()
        {
            // Arrange
            int? integer = null;

            // Act
            bool isNotIntegerNullOrLessThanOne = integer.NotNullOrLessThanOne();

            // Assert
            Assert.False(isNotIntegerNullOrLessThanOne);
        }

        [Fact]
        public void Should_Return_False_For_Less_Than_One()
        {
            // Arrange
            int? integer1 = 0;
            int? integer2 = -1;

            // Act
            bool isNotIntegerNullOrLessThanOne1 = integer1.NotNullOrLessThanOne();
            bool isNotIntegerNullOrLessThanOne2 = integer2.NotNullOrLessThanOne();

            // Assert
            Assert.False(isNotIntegerNullOrLessThanOne1);
            Assert.False(isNotIntegerNullOrLessThanOne2);
        }
    }
}