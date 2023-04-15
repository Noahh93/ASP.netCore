using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Common;
using System.Xml.Linq;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        List<Product> _products;
        List<Country> _countries;
        List<Category> _categories;
        public ProductController()
        {
            _products = new List<Product>();
            Product Piphone = new Product();
            Piphone.ID = 3001;
            Piphone.Name = "Iphone pro";
            Piphone.Quantity = 4;
            Piphone.ImagePath = "/images/iphone.png";
            Piphone.Price = 100;

            _products.Add(Piphone);

            Product Pjeans = new Product();
            Pjeans.ID = 2001;
            Pjeans.Name = "Iphone 10";
            Pjeans.Quantity = 21;
            Pjeans.ImagePath = "/images/iphone.png";
            Pjeans.Price = 25.99;

            _products.Add(Pjeans);

            Product Ptshirt = new Product();
            Ptshirt.ID = 1001;
            Ptshirt.Name = "Iphone 11";
            Ptshirt.Quantity = 6;
            Ptshirt.ImagePath = "/images/iphone.png";
            Ptshirt.Price = 99.95;

            _products.Add(Ptshirt);

            Product Plaptop = new Product();
            Plaptop.ID = 5001;
            Plaptop.Name = "Computer";
            Plaptop.Quantity = 2;
            Plaptop.ImagePath = "/images/laptop.png";
            Plaptop.Price = 45.00;

            _products.Add(Plaptop);

            //_________-------_________-------_________-------_________-------_________-------
            //_________-------_________-------_________-------_________-------_________-------

            _countries = new List<Country>();
            Country country = new Country();

            country.Id = 1;
            country.Name = "Sweden";

            _countries.Add(country);

            Country country2 = new Country();
            country2.Id = 2;
            country2.Name = "USA";

            _countries.Add(country2);

            Country country3 = new Country();
            country3.Id = 3;
            country3.Name = "Canada";

            _countries.Add(country3);

            Country country4 = new Country();
            country4.Id = 4;
            country4.Name = "Germany";

            _countries.Add(country4);

            //_________-------_________-------_________-------_________-------_________-------
            //_________-------_________-------_________-------_________-------_________-------

            _categories = new List<Category>();
            Category category = new Category();

            category.Category_ID = 1;
            category.Category_Name = "Electronics";

            _categories.Add(category);

            Category category2 = new Category();

            category2.Category_ID = 2;
            category2.Category_Name = "Fabrics";

            _categories.Add(category2);

            Category category3 = new Category();

            category3.Category_ID = 3;
            category3.Category_Name = "Accessories";

            _categories.Add(category3);
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
            ProductRepository DBproduct = new ProductRepository();
            Product productVariable = DBproduct.GetProductByID(id);

            if(productVariable == null)
            {
                return View();
            }
            else
            {
                return View(productVariable);
            }


        }
        public ActionResult GetAllProducts()
        {

            ProductRepository DBproduct = new ProductRepository();
            List<Product> product = DBproduct.GetAllProducts();
            return View(product);
        }
        //public ActionResult UpdateProductById(int id, string name, int quantity)
        //{
        //    if (_products[id].ID == id)
        //    {
        //        _products[id].Name = name;
        //        _products[id].Quantity = quantity;
        //        return "Product has been updated";
        //    }
        //    else
        //    {
        //        return "Product not updated";
        //    }

        //    Display all categories, display category by ID


        //    return View();
        //}
        public ActionResult GetAllTableProducts()
        {
            ProductRepository DBproduct = new ProductRepository();
            List<Product> product = DBproduct.GetAllProducts();
            return View(product);
        }
        public ActionResult ProductForm()
        {
            ViewBag.Countries = _countries;
            ViewBag.Categories = _categories;
            ViewBag.Error = "";
            return View();
        }                       //PRACTICE VIEW and VIEWBAG
        public ActionResult ProductSave(int id, string name, int quantity, int price, string imagepath)
        {
            ProductRepository DBproduct = new ProductRepository();
            DBproduct.CreateNewProduct( id, name, quantity, imagepath, price);
            List<Product> productList = DBproduct.GetAllProducts();

            return View("GetAllTableProducts", productList);
            //Product product = new Product();
            //product.ID = id;
            //product.Name = name;
            //product.Quantity = quantity;
            //product.Price = price;

            //if(product.Price > 5000)
            //{
            //    ViewBag.Countries = _countries;
            //    ViewBag.Categories = _categories;
            //    ViewBag.Error = "Product not saved, price exceeded 5000";
            //    return View("ProductForm");
            //}

            //_products.Add(product); //save into database instead of list
            //return View("GetAllTableProducts",_products);
        }
        public ActionResult UpdateProduct(int id)               
        {
            ProductRepository DBproduct = new ProductRepository();
            Product product = DBproduct.GetProductByID(id);

            return View("UpdateProduct", product);
        }
        public ActionResult UpdateProductSave(int id, string name, int quantity, int price)
        {
            ProductRepository DBproduct = new ProductRepository();
            DBproduct.UpdateProduct(id, name, quantity, price);
            List<Product> productList = DBproduct.GetAllProducts();

            return View("GetAllTableProducts", productList); 
        }
        public ActionResult DeleteProduct(int id)
        {
            ProductRepository DBproduct = new ProductRepository();
            DBproduct.DeleteProduct(id);
            List<Product> productList = DBproduct.GetAllProducts();

            return View("GetAllTableProducts", productList);
        }
        public ActionResult SearchProduct(string productName)
        {
            List<Product> products = new List<Product>();
            foreach (Product product in _products)
            {
                if(product.Name.ToLower().Contains(productName.ToLower()))  
                {
                    products.Add(product);
                }
            }

            ViewBag.amount = products.Count;
            return View("GetAllTableProducts", products);
        }
    }
}
