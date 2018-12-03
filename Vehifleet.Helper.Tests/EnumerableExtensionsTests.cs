using System.Collections.Generic;
using Vehifleet.Helper.Extensions;
using Xunit;

namespace Vehifleet.Helper.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void Should_Return_True_When_Not_Null_Or_Empty()
        {
            // Arrange            
            List<int> list = new List<int> {1, 2, 3};
            int[] array = {1, 2, 3};

            // Act            
            bool isListNotNullOrEmpty = list.NotNullOrEmpty();
            bool isArrayNotNullOrEmpty = array.NotNullOrEmpty();

            // Assert
            Assert.True(isListNotNullOrEmpty);
            Assert.True(isArrayNotNullOrEmpty);
        }

        [Fact]
        public void Should_Return_False_For_Empty_Enumerable()
        {
            // Arrange            
            List<int> list = new List<int>();
            int[] array = { };

            // Act            
            bool isListNotNullOrEmpty = list.NotNullOrEmpty();
            bool isArrayNotNullOrEmpty = array.NotNullOrEmpty();

            // Assert
            Assert.False(isListNotNullOrEmpty);
            Assert.False(isArrayNotNullOrEmpty);
        }

        [Fact]
        public void Should_Return_False_For_Null_Enumerable()
        {
            // Arrange            
            List<int> list = null;
            int[] array = null;

            // Act            
            bool isListNotNullOrEmpty = list.NotNullOrEmpty();
            bool isArrayNotNullOrEmpty = array.NotNullOrEmpty();

            // Assert
            Assert.False(isListNotNullOrEmpty);
            Assert.False(isArrayNotNullOrEmpty);
        }
    }
}