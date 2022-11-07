using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DemoTestFramework.helpers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace DemoTestFramework.validationTests
{
    public class GetPlanetValidationTests : ValidationTestBase
    {
        //https://json-schema.org/draft/2019-09/json-schema-validation.html#rfc.section.6.1
        
        private const string Host = "https://swapi.dev/api";
        private const string Endpoint = "/planets";
        
        [Test]
        public async Task GetPlanetsValidationTesting()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(Host + Endpoint);
            string content = await response.Content.ReadAsStringAsync();
            CheckValidationResponseBySchemaFromFile(content, "GetPlanets.Positive.json");
        }
        
    }
}