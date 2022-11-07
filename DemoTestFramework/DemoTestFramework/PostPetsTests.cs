using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DemoTestFramework.models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DemoTestFramework
{
    public class PostPetsTests : TestBase
    {

        private string Api = "https://petstore.swagger.io/v2/pet";

        [Test]
        public async Task PostPetsTesting()
        {
            HttpClient client = new HttpClient();
            string body = "{\"id\": 1,  \"category\": {\"id\": 1, \"name\": \"string\"},\"name\": \"doggie\", " +
                          "\"photoUrls\": [\"string\"],\"tags\": [{\"id\": 0, \"name\": \"string\"}],\"status\": " +
                          "\"available\"}";
            var postContent = new StringContent(body, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(Api, postContent );
            
            string content = await result.Content.ReadAsStringAsync();
            Pets? response = JsonConvert.DeserializeObject<Pets>(content);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Код ответа от апи не соответсвует ожидаемому");
            CustomAssertAreEqual(1, response.Id);
        }
        
        [Test]
        public async Task PostPetsByObjectTesting()
        {
            HttpClient client = new HttpClient();

            var request = new Pets()
            {
                Id = 1,
                Category = new Category()
                {
                    Id = 1,
                    Name = "dfsdfsf"
                },
                Name = "Fedor",
                PhotoUrls = new string [] {"sdfsdfs", "dsfdsfsdfsfd"},
                Status = "available",
                Tags = new []{ new Category()
                {
                    Id = 1,
                    Name = "dfsdfsf"
                } 
                },
            };

            var result = await client.PostAsJsonAsync(Api, request);
            Console.WriteLine(await result.Content.ReadAsStringAsync());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, "Код ответа от апи не соответсвует ожидаемому");
        }

    }
}