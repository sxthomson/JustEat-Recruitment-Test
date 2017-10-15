using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JustEat.TechTest.WebApi.Clients;
using JustEat.TechTest.WebApi.Responses;

namespace JustEat.TechTest.WebApi.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantOriginClient _restaurantOriginClient;
        private readonly IMapper _mapper;        

        public RestaurantService(IRestaurantOriginClient restaurantOriginClient, IMapper mapper)
        {
            _restaurantOriginClient = restaurantOriginClient;
            _mapper = mapper;            
        }

        public async Task<IEnumerable<RestaurantResponse>> GetRestaurantsAsync(string outcode)
        {
            var response = await _restaurantOriginClient.GetRestaurants(outcode);
            return _mapper.Map<IEnumerable<RestaurantResponse>>(response.Restaurants);
        }
    }
}