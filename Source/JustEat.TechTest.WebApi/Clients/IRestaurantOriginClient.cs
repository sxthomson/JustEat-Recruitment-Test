using System.Threading.Tasks;
using JustEat.TechTest.WebApi.DTO;

namespace JustEat.TechTest.WebApi.Clients
{
    public interface IRestaurantOriginClient
    {
        Task<RestaurantOriginResponse> GetRestaurants(string outcode);
    }
}