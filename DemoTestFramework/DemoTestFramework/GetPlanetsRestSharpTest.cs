using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using DemoTestFramework.models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace DemoTestFramework
{
    [Parallelizable(ParallelScope.All)]
    public class GetPlanetsRestSharpTest : TestBase
    {
        private string Endpoint;
        
        [SetUp]
        public void BeforeTest()
        {
            Endpoint = "/planets/";
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void GetPlanetsByRestSharpTesting(int page)
        {
            var client = new RestClient();
            RestRequest request = new RestRequest(Host + Endpoint, Method.Get);
            request.AddParameter("page", page);
            RestResponse response = client.Execute(request);
            ResponsePlanet result = JsonConvert.DeserializeObject<ResponsePlanet>(response.Content);
            
            
            /*
             //https://docs.nunit.org/articles/nunit/writing-tests/assertions/multiple-asserts.html
             Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(result.Next);
                Assert.AreEqual(result.Count, 60);
            });*/

            //CustomAssertIsNotNull(result.Next);
            //CustomAssertIsNull(result.Previous);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            CustomAssertAreEqual(result.Count, 60);
        }
    }
}