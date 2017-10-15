using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using JustEat.TechTest.WebApi.Services;

namespace JustEat.TechTest.WebApi.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IRestaurantService>()
                    .ImplementedBy<RestaurantService>()
                    .LifestyleSingleton());
        }
    }
}