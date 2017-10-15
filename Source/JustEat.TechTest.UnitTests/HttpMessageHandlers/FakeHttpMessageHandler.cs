using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JustEat.TechTest.UnitTests.HttpMessageHandlers
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            throw new NotImplementedException("This is designed to be used with a Mocking framework only!");
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(Send(request));
        }
    }
}
