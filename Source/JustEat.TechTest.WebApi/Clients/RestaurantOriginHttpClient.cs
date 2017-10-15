using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JustEat.TechTest.WebApi.DTO;
using Newtonsoft.Json;

namespace JustEat.TechTest.WebApi.Clients
{
    public class RestaurantOriginHttpClient : IRestaurantOriginClient
    {
        private readonly string _requestUriFormat;
        private readonly string _tenant;
        private readonly string _language;
        private readonly AuthenticationSchemes _authenticationSchemes;
        private readonly string _accessToken;
        private readonly string _host;

        private readonly HttpClient _httpClient;

        public RestaurantOriginHttpClient(string requestUriFormat, string tenant, string language, AuthenticationSchemes authenticationSchemes, string accessToken,
            string host, HttpClient httpClient)
        {
            _requestUriFormat = requestUriFormat;
            _tenant = tenant;
            _language = language;
            _authenticationSchemes = authenticationSchemes;
            _accessToken = accessToken;
            _host = host;
            _httpClient = httpClient;
        }

        public async Task<RestaurantOriginResponse> GetRestaurants(string outcode)
        {
            using (var request = BuildHttpRequestMessage(outcode))
            {
                var result = await _httpClient.SendAsync(request);
                var content = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RestaurantOriginResponse>(content);
                return response;
            }
        }

        private HttpRequestMessage BuildHttpRequestMessage(string outcode)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format(_requestUriFormat, outcode)),
                Method = HttpMethod.Get,
            };

            request.Headers.Add("Accept-Tenant", _tenant);
            request.Headers.Add("Accept-Language", _language);
            request.Headers.Add("Authorization", _authenticationSchemes + " " + _accessToken);
            request.Headers.Add("Host", _host);
            return request;
        }
    }
}