using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JustEat.TechTest.WebApi.Clients;
using JustEat.TechTest.WebApi.DTO;
using JustEat.TechTest.WebApi.Responses;
using JustEat.TechTest.WebApi.Services;
using Moq;
using NUnit.Framework;

namespace JustEat.TechTest.UnitTests.Services
{
    [TestFixture]
    public class RestaurantServiceShould
    {
        private Mock<IRestaurantOriginClient> _restaurantOriginClientMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _restaurantOriginClientMock = new Mock<IRestaurantOriginClient>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task Call_RestaurantOriginClient_With_Supplied_Outcode()
        {
            // Arrange
            const string expectedOutcode = "SE19";
            var restaurantService = new RestaurantService(_restaurantOriginClientMock.Object, _mapperMock.Object);
            var originResponse = new RestaurantOriginResponse { Restaurants = new List<Restaurant>() };
            _restaurantOriginClientMock.Setup(x => x.GetRestaurants(expectedOutcode)).ReturnsAsync(originResponse);
            // Act
            await restaurantService.GetRestaurantsAsync(expectedOutcode);

            // Assert
            _restaurantOriginClientMock.Verify(x => x.GetRestaurants(expectedOutcode), Times.Once);
        }

        [Test]
        public async Task Call_Mapper_With_Result_From_RestaurantOriginClient()
        {
            // Arrange            
            var expectedRestaurants = new List<Restaurant>();
            var expectedOriginResponse = new RestaurantOriginResponse { Restaurants = expectedRestaurants };
            _restaurantOriginClientMock.Setup(x => x.GetRestaurants(It.IsAny<string>()))
                .ReturnsAsync(expectedOriginResponse);
            var restaurantService = new RestaurantService(_restaurantOriginClientMock.Object, _mapperMock.Object);
            
            // Act
            await restaurantService.GetRestaurantsAsync("SE19");

            // Assert
            _mapperMock.Verify(x => x.Map<IEnumerable<RestaurantResponse>>(expectedRestaurants), Times.Once);
        }

        [Test]
        public async Task Return_The_Expected_Mapped_Restaurant_Responses()
        {
            // Arrange                        
            var expectedRestaurantsResponse = new List<RestaurantResponse>();
            var originResponse = new RestaurantOriginResponse {  Restaurants = new List<Restaurant>() };

            _restaurantOriginClientMock.Setup(x => x.GetRestaurants(It.IsAny<string>()))
                .ReturnsAsync(originResponse);

            _mapperMock.Setup(x => x.Map<IEnumerable<RestaurantResponse>>(It.IsAny<IEnumerable<Restaurant>>()))
                .Returns(expectedRestaurantsResponse);

            var restaurantService = new RestaurantService(_restaurantOriginClientMock.Object, _mapperMock.Object);

            // Act
            var actualRestaurantResponses = await restaurantService.GetRestaurantsAsync("SE19");

            // Assert
            Assert.That(actualRestaurantResponses, Is.EqualTo(expectedRestaurantsResponse));
        }
    }
}
