namespace DemoTestFramework.models
{
 
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}