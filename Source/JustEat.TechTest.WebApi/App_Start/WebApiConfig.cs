using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using JustEat.TechTest.WebApi.IoC;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JustEat.TechTest.WebApi
{
    public class WebApiConfig
    {
        private static IWindsorContainer _container;

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };            
            config.Formatters.JsonFormatter.SerializerSettings = jsonSerializerSettings;

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public static void InstallContainer(HttpConfiguration config)
        {
            _container = new WindsorContainer();
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel));
            _container.Install(FromAssembly.This());

            var httpDependencyResolver = new CastleWindsorHttpDependencyResolver(_container);

            config.DependencyResolver = httpDependencyResolver;
        }
    }
}