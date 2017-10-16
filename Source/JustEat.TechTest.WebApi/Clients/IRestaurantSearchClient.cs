using System.Threading.Tasks;
using JustEat.TechTest.WebApi.DTO;

namespace JustEat.TechTest.WebApi.Clients
{
    public interface IRestaurantSearchClient
    {
        Task<GetRestaurantResult> GetRestaurants(string outcode);
    }
}