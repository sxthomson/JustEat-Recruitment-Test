using System.Collections.Generic;

namespace JustEat.TechTest.WebApi.DTO
{
    public class RestaurantOriginResponse
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string ShortResultText { get; set; }
        public string Area { get; set; }
        public object Errors { get; set; }
        public bool HasErrors { get; set; }
        public MetaData MetaData { get; set; }
    }
}