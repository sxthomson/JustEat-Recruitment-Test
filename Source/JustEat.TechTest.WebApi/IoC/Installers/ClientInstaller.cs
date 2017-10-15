using System.Net;
using System.Net.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using JustEat.TechTest.WebApi.Clients;

namespace JustEat.TechTest.WebApi.Installers
{
    public class ClientInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var singletonHttpClient = new HttpClient();
            container.Register(Component.For<HttpClient>().Instance(singletonHttpClient));

            container.Register(
                Component.For<IRestaurantOriginClient>()
                    .ImplementedBy<RestaurantOriginHttpClient>()
                    .DependsOn(Dependency.OnValue("requestUriFormat", "http://public.je-apis.com/restaurants/?q={0}"))
                    .DependsOn(Dependency.OnValue("tenant", "uk"))
                    .DependsOn(Dependency.OnValue("language", "en-GB"))
                    .DependsOn(Dependency.OnValue("authenticationSchemes", AuthenticationSchemes.Basic))
                    .DependsOn(Dependency.OnValue("accessToken", "VGVjaFRlc3RBUEk6dXNlcjI="))
                    .DependsOn(Dependency.OnValue("host", "public.je-apis.com"))
                    .LifestyleSingleton());
        }
    }
}