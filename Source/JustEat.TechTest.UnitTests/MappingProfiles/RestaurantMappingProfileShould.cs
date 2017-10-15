using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JustEat.TechTest.WebApi.DTO;
using JustEat.TechTest.WebApi.MappingProfiles;
using JustEat.TechTest.WebApi.Responses;
using NUnit.Framework;

namespace JustEat.TechTest.UnitTests.MappingProfiles
{
    [TestFixture]
    public class RestaurantMappingProfileShould
    {
        [Test]
        public void Have_A_Valid_Configuration()
        {
            Mapper.Initialize(m => m.AddProfile<RestaurantMappingProfile>());
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Successfully_Map_The_Name_Of_A_Restaurant_To_A_RestaurantResponse()
        {
            // Arrange
            const string expectedRestaurantName = "MyRestaurantName";
            var restaurant = new Restaurant { Name = expectedRestaurantName };
            Mapper.Initialize(m => m.AddProfile<RestaurantMappingProfile>());

            // Act
            var mapped = Mapper.Map<RestaurantResponse>(restaurant);

            // Assert
            Assert.That(mapped.Name, Is.EqualTo(expectedRestaurantName));
        }

        [Test]
        public void Successfully_Map_The_Rating_Of_A_Restaurant_To_A_RestaurantResponse()
        {
            // Arrange
            const double expectedRatingAverage = 4.0;
            var restaurant = new Restaurant { RatingAverage = expectedRatingAverage };
            Mapper.Initialize(m => m.AddProfile<RestaurantMappingProfile>());

            // Act
            var mapped = Mapper.Map<RestaurantResponse>(restaurant);

            // Assert
            Assert.That(mapped.Rating, Is.EqualTo(expectedRatingAverage));
        }

        [Test]
        public void Successfully_Map_The_Cuisine_Types_Of_A_Restaurant_To_A_RestaurantResponse()
        {
            // Arrange
            var expectedCuisineTypes = new List<string> {"Italian", "Pizza"};
            var cuisineTypes = new List<CuisineType> {new CuisineType { Name = expectedCuisineTypes[0] }, new CuisineType { Name = expectedCuisineTypes[1] } };

            var restaurant = new Restaurant {  CuisineTypes = cuisineTypes };
            Mapper.Initialize(m => m.AddProfile<RestaurantMappingProfile>());

            // Act
            var mapped = Mapper.Map<RestaurantResponse>(restaurant);

            // Assert
            Assert.That(mapped.CuisineTypes, Is.EqualTo(expectedCuisineTypes));
        }

        [Test]
        public void Successfully_Maps_A_Collection_Of_Restaurants_To_A_Collection_Of_RestaurantResponses()
        {
            // Arrange
            var restaurantList = new List<Restaurant> { new Restaurant(), new Restaurant() };            
            Mapper.Initialize(m => m.AddProfile<RestaurantMappingProfile>());

            // Act
            var mapped = Mapper.Map<IEnumerable<RestaurantResponse>>(restaurantList);

            // Assert
            Assert.That(mapped.Count(), Is.EqualTo(restaurantList.Count));            
        }
    }
}
