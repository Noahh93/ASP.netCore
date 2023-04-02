using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        Category[] _categories;
        public CategoryController() 
        {
            Product product1 = new Product();
            product1.ID = 1;
            product1.Name = "A";
            product1.Quantity = 1;

            _categories[0] = new Category();
            _categories[0].Category_ID = 1;
            _categories[0].Category_Name = "Electronics";
            _categories[0].Category_Description = "This is the category of Electronics products";

            Product product2 = new Product();
            product2.ID = 2;
            product2.Name = "B";
            product2.Quantity = 1;

            _categories[1] = new Category();
            _categories[1].Category_ID = 1;
            _categories[1].Category_Name = "Clothes";
            _categories[1].Category_Description = "This is the category of Clothes products";

        }
        public string Index()
        {
            return "Welcome to Category Page";
        }
        public string CategoryName()
        {
            return "Phone Category";
        }
        public int CategoryPrice()
        {
            return 200;
        }
        public string CategoryDetail(int id, string name)
        {
            return $"Product ID is {id} and name is {name}";
        }
        public string GetCategoryByID(int id)
        {
            return $"This Category contains Category ID:{_categories[id].Category_ID}," +
                                        $"Category Name:{_categories[id].Category_Name}," +
                                 $"Category Description:{_categories[id].Category_Description}";
        }
        public ActionResult GetAllProducts()
        {
            string result = "";
            for (int i = 0; i < _categories.Length; i++)
            {
                result = result + $"Category ID: {_categories[i].Category_ID}," +
                $"Category ID: Category Name: {_categories[i].Category_Name}," +
                $"Category Description: {_categories[i].Category_Description},";
            }
            return Content(result);
        }
    }
}
