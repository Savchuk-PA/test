namespace DemoTestFramework.models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}