[Fact]
public async void Should_Return_Filtered_Vehicles()
{
    // Arrange
    var vehicles = DataProvider.GetVehicles();
    var vehiclesMock = vehicles.AsQueryable().BuildMock();
    var filter = new VehicleFilter
    {
        Manufacturer = "Ford"
    };
    var vehicleRepositoryMock
        = new Mock<IGenericRepository<Vehicle, int>>();
    vehicleRepositoryMock.Setup(m => m.Get())
                         .Returns(vehiclesMock.Object);
    var vehicleController
        = new VehicleController(
            vehicleRepositoryMock.Object,
            Mock.Of<IGenericRepository<VehicleModel, int>>(),
            Mock.Of<IGenericRepository<Booking, int>>(),
            MapperProvider.GetMapper());
    // Act
    var request = await vehicleController.Get(filter);
    var result = request as OkObjectResult;

    // Assert
    Assert.NotNull(result);
    Assert.True(result.StatusCode == 200);
    var dtos = result.Value as List<VehicleListItemDto>;
    Assert.NotNull(dtos);
    Assert.True(dtos.Count == 2);
}