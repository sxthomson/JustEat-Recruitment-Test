using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using JustEat.TechTest.WebApi.MappingProfiles;

namespace JustEat.TechTest.WebApi.Installers
{
    public class MapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMapper>().UsingFactoryMethod(x =>
                {
                    return new MapperConfiguration(c =>
                    {
                        c.AddProfile<RestaurantMappingProfile>();
                    }).CreateMapper();
                }));            
                
        }
    }
}