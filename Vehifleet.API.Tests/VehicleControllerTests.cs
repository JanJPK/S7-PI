using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockQueryable.Moq;
using Moq;
using Vehifleet.API.Controllers;
using Vehifleet.API.QueryFilters;
using Vehifleet.Data.Models;
using Vehifleet.Repositories;
using Vehifleet.Repositories.Interfaces;
using Xunit;

namespace Vehifleet.API.Tests
{
    public class VehicleControllerTests
    {
        [Fact]
        public async void Test()
        {
            // Arrange            
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 1,
                    VehicleModel =  new VehicleModel
                    {
                        Id = 1
                    },
                    Location = new Location
                    {
                        LocationCode = "1"
                    }
                },
                new Vehicle
                {
                    Id = 2,
                    VehicleModel =  new VehicleModel
                    {
                        Id = 1
                    },
                    Location = new Location
                    {
                        LocationCode = "1"
                    }
                },
                new Vehicle
                {
                    Id = 3,
                    VehicleModel =  new VehicleModel
                    {
                        Id = 1
                    },
                    Location = new Location
                    {
                        LocationCode = "1"
                    }
                }
            };

            var mock = vehicles.AsQueryable().BuildMock();
            var vehicleRepositoryMock = new Mock<IGenericRepository<Vehicle, int>>();
            vehicleRepositoryMock.Setup(m => m.Get()).Returns(mock.Object);

            //vehicleRepository.Setup<()



            //var vehicleRepositoryMock = new Mock<IGenericRepository<Vehicle, int>>();
            //vehicleRepositoryMock.Setup(m => m.Get())
            //vehicleRepositoryMock.Setup<Task<IQueryable<Vehicle>>>(m => m.Get())
            //                     .Returns(Task.FromResult<IQueryable<Vehicle>>(vehicle.AsQueryable()));
            //var vehicleController = new VehicleController(vehicleRepositoryMock.Object,
            //                                              Mock.Of<IGenericRepository<VehicleModel, int>>(),
            //                                              Mock.Of<IGenericRepository<Booking, int>>());
            //// Act
            //var getVehicle = await vehicleController.Get(new VehicleFilter());
            int dupa = 1;
            // Assert

        }
    }
}