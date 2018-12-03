using Vehifleet.Helper.Extensions;
using Xunit;

namespace Vehifleet.Helper.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Should_Add_Spaces_1()
        {
            // Arrange
            var text = "SomeTestText";
            var expected = "Some Test Text";

            // Act
            var actual = text.AddSpaces();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Add_Spaces_2()
        {
            // Arrange
            var text = "ABCDEF";
            var expected = "A B C D E F";

            // Act
            var actual = text.AddSpaces();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Remove_Spaces_1()
        {
            // Arrange
            var text = "AnotherTestExample";
            var expected = "Another Test Example";

            // Act
            var actual = text.RemoveSpaces();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Remove_Spaces_2()
        {
            // Arrange
            var text = "G H I J K";
            var expected = "GHIJK";

            // Act
            var actual = text.RemoveSpaces();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Remove_Multiple_Spaces()
        {
            // Arrange
            var text = "Start     End";
            var expected = "StartEnd";

            // Act
            var actual = text.RemoveSpaces();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}