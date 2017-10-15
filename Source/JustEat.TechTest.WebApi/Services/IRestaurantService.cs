using System.Collections.Generic;
using System.Threading.Tasks;
using JustEat.TechTest.WebApi.Responses;

namespace JustEat.TechTest.WebApi.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantResponse>> GetRestaurantsAsync(string outcode);
    }
}