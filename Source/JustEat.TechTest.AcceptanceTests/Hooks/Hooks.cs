using System;
using System.Net.Http;
using JustEat.TechTest.WebApi;
using Microsoft.Owin.Hosting;
using TechTalk.SpecFlow;

namespace JustEat.TechTest.AcceptanceTests.Hooks
{
    public class Hooks
    {
        private IDisposable _app;
        protected HttpClient ApiClient;

        [Before("SelfHostedApi")]
        public void SetUp()
        {
            var port = TcpPorts.GetFreeTcpPort();
            var baseUri = "http://localhost:" + port; 
            ApiClient = new HttpClient { BaseAddress = new Uri(baseUri) };
            _app = WebApp.Start<Startup>(baseUri);
        }

        [After("SelfHostedApi")]
        public void TearDown()
        {
            _app.Dispose();
        }        
    }
}
