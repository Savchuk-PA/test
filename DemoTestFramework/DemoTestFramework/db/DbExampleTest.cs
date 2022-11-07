using System;
using System.Collections.Generic;
using System.Linq;
using DemoTestFramework.db;
using DemoTestFramework.models;
using Newtonsoft.Json;
using Npgsql;
using NUnit.Framework;
using RestSharp;

namespace DemoTestFramework
{
    public class DbExampleTest
    {
        private string Endpoint;
        
        [SetUp]
        public void BeforeTest()
        {
            Endpoint = "https://swapi.dev/api/planets/";
        }
        
        [Test]
        [TestCase(1)]
        public void GetPlanetsByRestSharpTesting(int page)
        {

            var client = new RestClient();
            RestRequest request = new RestRequest(Endpoint, Method.Get);
            request.AddParameter("page", page);
            RestResponse response = client.Execute(request);
            ResponsePlanet result = JsonConvert.DeserializeObject<ResponsePlanet>(response.Content);

            using (DemoContextDb contextDb = new DemoContextDb())
            {
                for (int i = 0; i < result.Results.Length; i++)
                {
                    result.Results[i].Id = i + 1;
                    contextDb.Planets.AddRange(result.Results[i]);
                }
                contextDb.SaveChanges();
            }

        }

       
        [Test]
        public void CreateDataInDb()
        {

            Person person = new Person() { FirstName = "Petr", SecondName = "Petrov", MiddleName = "Petrovich"};
            Person person1 = new Person() {  FirstName = "Петр", SecondName = "Петров", MiddleName = "Петрович"};
            Animal animal = new Animal() { Name = "Федор", Type = "кот", Person = person};
            Animal animal1 = new Animal() { Name = "Барсик", Type = "пес", Person = person};
            Animal animal2 = new Animal() { Name = "Федор", Type = "кот", Person = person1};
            Car car = new Car() {Model = "bmw", Year = "2012", Person = person};
            
            using (DemoContextDb contextDb = new DemoContextDb())
            {
                
                contextDb.Persons.AddRange(person);
                contextDb.Persons.AddRange(person1);
                contextDb.Animals.AddRange(animal);
                contextDb.Animals.AddRange(animal1);
                contextDb.Animals.AddRange(animal2);
                contextDb.Cars.AddRange(car);
               
                contextDb.SaveChanges();
            }
        }
        
        [Test]
        public void SelectDataFromDb()
        {
            using (DemoContextDb contextDb = new DemoContextDb())
            {
                Planet? planet = contextDb.Planets.FirstOrDefault(p => p.Name == "Hoth");
                Assert.AreEqual(4, planet.Id);

                List<Planet?> listPlanets = contextDb.Planets.ToList();
                List<int> ids = contextDb.Planets.Select(p => p.Id).Where(p => p > 4).ToList();

                planet.Name = "sdfsdgvdsgsdg";
                contextDb.SaveChanges();
            }
        }

        
        // Ado.net
        [Test]
        public void AdoExample()
        {
            string connectionString = "Host=localhost;Port=5432;Database=demo;Username=postgres;Password=admin";
            using (var connect = new NpgsqlConnection(connectionString))
            {
                connect.Open();
                string sql =
                    "SELECT id, name, align, eye, hair, gender, appearances, year, universe FROM public.superheroes";
                var cmd = new NpgsqlCommand(sql, connect);
                var result = cmd.ExecuteReader();

                Dictionary<int, string> superHeroes = new Dictionary<int, string>();

                while (result.Read())
                {
                    superHeroes.Add((int)result["id"], (string)result["name"]);
                }

                Console.WriteLine(superHeroes);
                connect.Close();
            }
        }
        
         public Planet? createPlanet(Planet? planet, bool isSunSystem = true){

            if (isSunSystem)
            {
                //// 
            }
            else
            {
                ////
                ///
                ///
                return null;
            }

            return planet;
        }
    }
    
    

}