using Newtonsoft.Json;

namespace DemoTestFramework.models
{
    public class Planet
    {
        public int Id { get; set; }
        
        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("rotation_period")] 
        public string RotationPeriod { get; set; }

        [JsonProperty("orbital_period")] 
        public string OrbitalPeriod { get; set; }

        [JsonProperty("diameter")] 
        public string Diameter { get; set; }

        [JsonProperty("climate")] 
        public string Climate { get; set; }

        [JsonProperty("gravity")] public string Gravity { get; set; }

        [JsonProperty("terrain")] public string Terrain { get; set; }

        [JsonProperty("surface_water")] public string SurfaceWater { get; set; }

        [JsonProperty("population")] public string Population { get; set; }

        [JsonProperty("residents")] public string[] Residents { get; set; }

        [JsonProperty("films")] public string[] Films { get; set; }

        [JsonProperty("created")] public string Created { get; set; }

        [JsonProperty("edited")] public string Edited { get; set; }

        [JsonProperty("url")] public string Url { get; set; }


        public Planet changeRotationPeriod()
        {
            this.RotationPeriod = "dfsdfsdf";
            return this;
        }
    }

    public class ResponsePlanet
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("next")]
        public string Next { get; set; }
        
        [JsonProperty("previous")]
        public string Previous { get; set; }
        
        [JsonProperty("results")]
        public Planet?[] Results { get; set; }
    }

}