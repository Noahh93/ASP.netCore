namespace WebApp.Models
{
    public class Category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public string Category_Description { get; set; }
        public string ImagePath { get; set; }
        public List<Product> Products { get; set; }
    }
}
