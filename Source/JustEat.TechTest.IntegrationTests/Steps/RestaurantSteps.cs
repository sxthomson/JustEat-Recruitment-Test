using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace JustEat.TechTest.AcceptanceTests.Steps
{
    [Binding]
    public sealed class RestaurantSteps : Hooks.Hooks
    {
        private string _outcode;
        private HttpResponseMessage _httpResponseMessage;

        [Given(@"a known outcode ""(.*)""")]
        public void GivenAKnownOutcode(string outcode)
        {
            _outcode = outcode;
        }

        [When(@"I request restaurant information from the api")]
        public async Task WhenIRequestRestaurantInformationFromTheApi()
        {
            _httpResponseMessage = await ApiClient.GetAsync("/restaurants/" + _outcode);
        }

        [Then(@"restaurants are returned")]
        public async Task ThenRestaurantsAreReturned()
        {
            var content = await _httpResponseMessage.Content.ReadAsStringAsync();
            var restaurants = JArray.Parse(content);

            Assert.That(restaurants.Count, Is.GreaterThan(0));
        }

        [Then(@"the name, cuisine types and ratings of the restaurants are returned")]
        public async Task ThenTheNameCuisineTypesAndRatingsOfTheRestaurantsAreReturned()
        {
            var content = await _httpResponseMessage.Content.ReadAsStringAsync();
            var restaurants = JArray.Parse(content);

            foreach (var restaurant in restaurants)
            {
                Assert.That(restaurant["name"].ToString(), Is.Not.Null.And.Not.Empty);
                Assert.That(restaurant["rating"].ToString(), Is.Not.Null.And.Not.Empty);
                Assert.That(restaurant["cuisineTypes"].Children().Count(), Is.GreaterThan(0));
            }
        }
    }
}
