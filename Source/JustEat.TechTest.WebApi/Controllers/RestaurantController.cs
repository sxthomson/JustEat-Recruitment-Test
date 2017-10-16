using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using JustEat.TechTest.WebApi.Responses;
using JustEat.TechTest.WebApi.Services;

namespace JustEat.TechTest.WebApi.Controllers
{
    [RoutePrefix("restaurants")]
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [Route("{outcode}")]
        public async Task<IEnumerable<RestaurantResponse>> Get(string outcode)
        {
            return await _restaurantService.GetRestaurantsAsync(outcode);
        }
    }
}