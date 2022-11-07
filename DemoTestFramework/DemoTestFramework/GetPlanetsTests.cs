using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DemoTestFramework.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace DemoTestFramework
{

    public class Tests : TestBase
    {

        private const string Endpoint = "/planets";
        private HttpClient _client;
        
       

        [OneTimeSetUp]
        public void BeforeClass()
        {
            // один раз перед всеми тестами этого класса
            _client = new HttpClient();
        }
        
        [SetUp]
        public void Setup()
        {
            // перед каждым тестом
        }

        // приведение ответа от апи к JSON
        [Test]
        public async Task GetPlanetsTesting()
        {
            /*
            Dictionary<int, string> listPlanets = new Dictionary<int, string>();
            listPlanets.Add(2, "IUHOIU");
            listPlanets.Add(42, "IUHOIU");
            listPlanets.Add(1, "IUHOIU");
            listPlanets.Add(3, "IUHOIU");
            
            
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add("Sveta", "QA");
            list.Add("Pasha", "Devops");
            list.Add("Ignat", "AQA");
            */


            
            var result = await _client.GetAsync(Host + Endpoint);
            string content = await result.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Код ответа от апи не соответсвует ожидаемому");
            Assert.AreEqual("60", json["count"].ToString());
            Assert.NotNull(json["next"]);
        }
        
        
        // приведение ответа от апи к классу
        [Test]
        public async Task GetPlanetsByObjectTesting()
        {
            var result = await _client.GetAsync(Host + Endpoint);
            string content = await result.Content.ReadAsStringAsync();
            ResponsePlanet response = JsonConvert.DeserializeObject<ResponsePlanet>(content);
  
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Код ответа от апи не соответсвует ожидаемому");
        }
    }
}