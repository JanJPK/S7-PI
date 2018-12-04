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