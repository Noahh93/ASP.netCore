using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
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
            Piphone.ImagePath = "/images/iphone.png";
            Piphone.Price = 100;

            _products.Add(Piphone);

            Product Pjeans = new Product();
            Pjeans.ID = 2;
            Pjeans.Name = "Fahinable Jeans";
            Pjeans.Quantity = 21;
            Pjeans.ImagePath = "/images/jeans.png";
            Pjeans.Price = 25.99;

            _products.Add(Pjeans);

            Product Ptshirt = new Product();
            Ptshirt.ID = 3;
            Ptshirt.Name = "Quick Computer";
            Ptshirt.Quantity = 6;
            Ptshirt.ImagePath = "/images/tshirt.png";
            Ptshirt.Price = 99.95;

            _products.Add(Ptshirt);

            Product Plaptop = new Product();
            Plaptop.ID = 4;
            Plaptop.Name = "New generation";
            Plaptop.Quantity = 2;
            Plaptop.ImagePath = "/images/laptop.png";
            Plaptop.Price = 45.00;


            _products.Add(Plaptop);
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
        public ActionResult GetProductByID(int id)
        {
            foreach (Product product in _products)
            {
                if (product.ID == id)
                {
                    return View(product);
                }
            }
            Product product1 = new Product();
            return View(product1);

        }
        public ActionResult GetAllProducts()
        {
            
            return View(_products);
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
        public ActionResult GetAllTableProducts()
        {
            return View(_products);
        }
        public ActionResult ProductForm()
        {
            return View();
        }
        public ActionResult ProductSave(int id, string name, int quantity, int price)
        {
            Product product = new Product();
            product.ID = id;
            product.Name = name;
            product.Quantity = quantity;
            product.Price = price;
            

            _products.Add(product);
            return View("GetAllTableProducts",_products);
        }
        public ActionResult UpdateProduct(int id)
        {
            foreach(Product product in _products)
            {
                if(product.ID == id)
                {
                    return View(product);
                }

            }

            return View("GetAllTableProducts", _products);
        }
        public ActionResult UpdateProductSave(int id, string name, int quantity, double price)
        {
            foreach (Product product in _products)
            {
                if (product.ID == id)
                {
                    product.Name = name;
                    product.Quantity = quantity;
                    product.Price = price;
                    break;
                }

            }

            return View("GetAllTableProducts", _products); //With updated values ASSIGNMENT
        }
        public ActionResult DeleteProduct(int id)
        {
            foreach (Product product in _products)
            {
                if (product.ID == id)
                {
                    _products.Remove(product);
                    break;
                }

            }
            return View("GetAllTableProducts", _products);
        }
    }
}
