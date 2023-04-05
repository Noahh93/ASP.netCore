namespace WebApp.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }

        public Category Category { get; set; }
    }
}
