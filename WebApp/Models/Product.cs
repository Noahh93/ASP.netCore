namespace WebApp.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }

        public int HomeCategory { get; set; }
        public Category Category { get; set; }

        public int HomeCountry { get; set; }
        public Country Country { get; set; }
    }
}
