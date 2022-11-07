using Newtonsoft.Json;

namespace DemoTestFramework.models
{
    public class Pets
    {
        
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("category")]
        public Category Category { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("photoUrls")]
        public string[] PhotoUrls { get; set; }
        
        [JsonProperty("tags")]
        public Category[] Tags { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}