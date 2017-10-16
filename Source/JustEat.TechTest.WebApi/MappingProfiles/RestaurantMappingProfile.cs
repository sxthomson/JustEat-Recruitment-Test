using System.Linq;
using AutoMapper;
using JustEat.TechTest.WebApi.DTO;
using JustEat.TechTest.WebApi.Responses;

namespace JustEat.TechTest.WebApi.MappingProfiles
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<RestaurantSearchResult, RestaurantResponse>()
                .ForMember(d => d.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(d => d.Rating,
                    opt => opt.MapFrom(src => src.RatingAverage)
                )
                .ForMember(d => d.CuisineTypes,
                    opt => opt.MapFrom(src => src.CuisineTypes.Select(ct => ct.Name))
                );
        }
    }
}