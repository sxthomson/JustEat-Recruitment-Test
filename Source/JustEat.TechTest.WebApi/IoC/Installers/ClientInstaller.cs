using System.Net;
using System.Net.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using JustEat.TechTest.WebApi.Clients;
using JustEat.TechTest.WebApi.Configuration;

namespace JustEat.TechTest.WebApi.Installers
{
    public class ClientInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var singletonHttpClient = new HttpClient();
            container.Register(Component.For<HttpClient>().Instance(singletonHttpClient));

            container.Register(
                Component.For<IRestaurantSearchClient>()
                    .ImplementedBy<RestaurantSearchHttpClient>()
                    .DependsOn(Dependency.OnValue("requestUriFormat", Settings.Uri.RequestUriFormat))
                    .DependsOn(Dependency.OnValue("tenant", Settings.RequestHeaders.Tenant))
                    .DependsOn(Dependency.OnValue("language", Settings.RequestHeaders.Language))
                    .DependsOn(Dependency.OnValue("authenticationSchemes", Settings.RequestHeaders.AuthenticationScheme))
                    .DependsOn(Dependency.OnValue("authorizationToken", Settings.RequestHeaders.AuthorizationToken))
                    .DependsOn(Dependency.OnValue("host", Settings.RequestHeaders.Host))
                    .LifestyleSingleton());
        }
    }
}