using System.Collections.Generic;

namespace JustEat.TechTest.WebApi.Responses
{
    public class RestaurantResponse
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public IEnumerable<string> CuisineTypes { get; set; }
    }
}