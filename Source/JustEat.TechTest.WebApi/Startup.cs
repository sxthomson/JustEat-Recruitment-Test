using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JustEat.TechTest.WebApi.Startup))]

namespace JustEat.TechTest.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            WebApiConfig.InstallContainer(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}