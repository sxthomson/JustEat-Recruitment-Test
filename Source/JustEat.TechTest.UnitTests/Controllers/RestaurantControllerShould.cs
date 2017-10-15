using System.Collections.Generic;
using System.Threading.Tasks;
using JustEat.TechTest.WebApi.Controllers;
using JustEat.TechTest.WebApi.Responses;
using JustEat.TechTest.WebApi.Services;
using Moq;
using NUnit.Framework;

namespace JustEat.TechTest.UnitTests.Controllers
{
    [TestFixture]
    public class RestaurantControllerShould
    {
        [Test]
        public async Task Call_RestaurantService_With_Supplied_Outcode()
        {
            // Arrange
            var mockRestaurantService = new Mock<IRestaurantService>();
            var controller = new RestaurantController(mockRestaurantService.Object);

            // Act
            await controller.Get("SE19");

            // Assert
            mockRestaurantService.Verify(x => x.GetRestaurantsAsync("SE19"), Times.Once);
        }

        [Test]
        public async Task Return_The_Expected_Restaurant_Responses_From_The_RestaurantService()
        {
            var expectedRestaurantResponses = new List<RestaurantResponse>();
            var mockRestaurantService = new Mock<IRestaurantService>();
            mockRestaurantService.Setup(x => x.GetRestaurantsAsync("SE19")).ReturnsAsync(expectedRestaurantResponses);
            var controller = new RestaurantController(mockRestaurantService.Object);

            // Act
            var actualRestaurantResponses = await controller.Get("SE19");

            // Assert
            Assert.That(actualRestaurantResponses, Is.EqualTo(expectedRestaurantResponses));
        }
    }
}