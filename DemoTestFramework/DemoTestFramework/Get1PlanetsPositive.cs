using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DemoTestFramework.models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DemoTestFramework
{
    public class Get1PlanetsPositive
    {
        private HttpClient _client;
        private const string Host = "https://swapi.dev/api";
        private const string Endpoint = "/planets";
        private ResponsePlanet response;
        
        [OneTimeSetUp]
        public async Task BeforeClass()
        {
            
            // один раз перед всеми тестами этого класса
            _client = new HttpClient();
            var result = await _client.GetAsync(Host + Endpoint);
            string content = await result.Content.ReadAsStringAsync();
            response = JsonConvert.DeserializeObject<ResponsePlanet>(content);

        }
        
        [Test]
        public void CheckCountPlanets()
        {

            Assert.AreEqual(60, response.Count);
        }
        
        [Test]
        public void CheckCountPrevious()
        {
            Assert.AreEqual(null, response.Previous);
        }
    }
}