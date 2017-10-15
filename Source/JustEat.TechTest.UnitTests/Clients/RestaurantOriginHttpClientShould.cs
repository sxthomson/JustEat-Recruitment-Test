using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JustEat.TechTest.UnitTests.HttpMessageHandlers;
using JustEat.TechTest.WebApi.Clients;
using Moq;
using NUnit.Framework;

namespace JustEat.TechTest.UnitTests.Clients
{
    [TestFixture]
    public class RestaurantOriginHttpClientShould
    {
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private HttpClient _httpClient;

        [SetUp]
        public void SetUp()
        {
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };

            _fakeHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{}") //Empty JSON response
            });

            _httpClient = new HttpClient(_fakeHttpMessageHandler.Object);
        }

        [Test]
        public async Task Send_A_Request_To_The_Correct_Outbound_Uri()
        {
            // Arrange
            const string expectedOutboundRequestUri = "http://localhost/?q=SE19";
            var client = new RestaurantOriginHttpClient("http://localhost/?q={0}", "tenant", "language", AuthenticationSchemes.Basic, "accessToken", "host", _httpClient);

            // Act
            await client.GetRestaurants("SE19");

            // Assert
            _fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(message => message.RequestUri.ToString() == expectedOutboundRequestUri)));
        }

        [Test]
        public async Task Apply_The_Correct_Accept_Tenant_Header_To_Its_Outbound_Request()
        {
            // Arrange
            const string expectedHeaderValue = "tenant";
            var client = new RestaurantOriginHttpClient("http://localhost/?q={0}", "tenant", "language", AuthenticationSchemes.Basic, "accessToken", "host", _httpClient);

            // Act
            await client.GetRestaurants("SE19");

            // Assert
            _fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(message => message.Headers.First(header => header.Key == "Accept-Tenant").Value.ToList()[0] == expectedHeaderValue)));
        }

        [Test]
        public async Task Apply_The_Correct_Accept_Language_Header_To_Its_Outbound_Request()
        {
            // Arrange
            const string expectedHeaderValue = "language";
            var client = new RestaurantOriginHttpClient("http://localhost/?q={0}", "tenant", "language", AuthenticationSchemes.Basic, "accessToken", "host", _httpClient);

            // Act
            await client.GetRestaurants("SE19");
            
            // Assert
            _fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(message => message.Headers.First(header => header.Key == "Accept-Language").Value.ToList()[0] == expectedHeaderValue)));
        }

        [Test]
        public async Task Apply_The_Correct_Authorization_Header_To_Its_Outbound_Request()
        {
            // Arrange
            const string expectedHeaderValue = "Basic accessToken";
            var client = new RestaurantOriginHttpClient("http://localhost/?q={0}", "tenant", "language", AuthenticationSchemes.Basic, "accessToken", "host", _httpClient);

            // Act
            await client.GetRestaurants("SE19");

            // Assert
            _fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(message => message.Headers.First(header => header.Key == "Authorization").Value.ToList()[0] == expectedHeaderValue)));
        }

        [Test]
        public async Task Apply_The_Correct_Host_Header_To_Its_Outbound_Request()
        {
            const string expectedHeaderValue = "host";
            var client = new RestaurantOriginHttpClient("http://localhost/?q={0}", "tenant", "language", AuthenticationSchemes.Basic, "accessToken", "host", _httpClient);

            await client.GetRestaurants("SE19");
            _fakeHttpMessageHandler.Verify(x => x.Send(It.Is<HttpRequestMessage>(message => message.Headers.First(header => header.Key == "Host").Value.ToList()[0] == expectedHeaderValue)));
        }
    }
}
