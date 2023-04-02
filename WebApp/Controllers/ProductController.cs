using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        List<Product> _products;
        public ProductController()
        {
            _products = new List<Product>();
            Product Piphone = new Product();
            Piphone.ID = 1;
            Piphone.Name = "iphone X10";
            Piphone.Quantity = 4;

            _products.Add(Piphone);

            Product Pumbrella = new Product();
            Pumbrella.ID = 2;
            Pumbrella.Name = "Luxury umbrella";
            Pumbrella.Quantity = 21;

            _products.Add(Pumbrella);

            Product Pipad = new Product();
            Pipad.ID = 3;
            Pipad.Name = "Quick Computer";
            Pipad.Quantity = 6;

            _products.Add(Pipad);

            Product Plaptop = new Product();
            Plaptop.ID = 4;
            Plaptop.Name = "New generation";
            Plaptop.Quantity = 2;

            _products.Add(Plaptop);
        }
        public ActionResult Index()
        {
            return View();
        }
        public string ProductName(string name)
        {
            return $"Productname is {name}";
        }
        public ActionResult ProductPrice()
        {
            return View();
        }
        public string ProductDetail(int id, string name, int quantity)
        {
            string detail = $"ProductName is Iphone and product id is {id}";
            return detail;
        }
        //public string GetProductByID(int id)
        //{
        //    string[] products = new string[5];
        //    products[0] = "Iphone";
        //    products[1] = "Jeans";
        //    products[2] = "Glases";
        //    products[3] = "Hat";
        //    products[4] = "Umbrella";

        //    if(id > 4)
        //    {
        //        return "Number too high, product not found!";
        //    }
        //    return products[id];
        //}
        public string GetProductByID(int id)
        {
            Category electronicsCTY = new Category();

            if (id > 4)
            {
                return "Not available!";
            }
            else
            {
                return $"ProductID is {_products[id].ID}, " +
                    $"and ProductName is {_products[id].Name}, " +
                    $"ProductQuantity is {_products[id].Quantity}, " +
                    $"Category ID: {_products[id].Category.Category_ID}, " + 
                    $"Category Name: {_products[id].Category.Category_Name}" +
                    $"Category Description: {_products[id].Category.Category_Description}";
            }

        }
        public ActionResult GetAllProducts()
        {
            string result = "";
            for (int i = 0; i < 4; i++)
            {
                //result = result + $"ProductID is {_products[i].ID}, " +
                //    $"and ProductName is {_products[i].Name}, " +
                //    $"ProductQuantity is {_products[i].Quantity}, " +
                //    $"Category ID: {_products[i].Category.Category_ID}, " +
                //    $"Category Name: {_products[i].Category.Category_Name}" +
                //    $"Category Description: {_products[i].Category.Category_Description}\n\n";
            }

            //string result = "abc\n";
            //result = result + "def\n";
            //result = result + "ghi";
            //return Content(result);
            return View();
        }
        public ActionResult UpdateProductById(int id, string name, int quantity)
        {
            //if(_products[id].ID == id)
            //{
            //    _products[id].Name = name;
            //    _products[id].Quantity = quantity;
            //    return "Product has been updated";
            //}
            //else
            //{
            //    return "Product not updated";
            //}

            //Display all categories, display category by ID
            //
            return View();
        }
        public ActionResult ProductAmazon()
        {
            return View();
        }
    }
}
