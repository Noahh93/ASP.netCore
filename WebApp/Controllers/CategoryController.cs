using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        List<Category> _categories;
        public CategoryController() 
        {
            _categories = new List<Category>();
            Category category = new Category();
            category.Category_ID = 1;
            category.Category_Name = "Electronics";
            category.Category_Description = "Description";
            category.ImagePath = "/images/laptop.png";

            _categories.Add(category);

            Category category2 = new Category();
            category2.Category_ID = 2;
            category2.Category_Name = "Fabrics";
            category2.Category_Description = "Description";
            category2.ImagePath = "/images/jeans.png";

            _categories.Add(category2);

            Category category3 = new Category();
            category3.Category_ID = 3;
            category3.Category_Name = "Accessories";
            category3.Category_Description = "Description";
            category3.ImagePath = "/images/iphone.png";

            _categories.Add(category3);

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
        public ActionResult GetCategoryByID(int id)
        {
            foreach(Category category in _categories)
            {
                if(category.Category_ID == id)
                {
                    return View(category);
                }
            }

            Category category1 = new Category();
            return View(category1);
        }
        public ActionResult GetAllCategories()
        {
            return View(_categories);
        }
        public ActionResult GetAllTableCategories()
        {
            return View(_categories);
        }
        public ActionResult CategoryForm()
        {
            return View();
        }
        public ActionResult CategorySave(int id, string name, string description)
        {
            Category category = new Category();
            category.Category_ID = id;
            category.Category_Name = name;
            category.Category_Description = description;

            _categories.Add(category);
            return View("GetAllTableCategories", _categories);
        }
        public ActionResult UpdateCategory(int id, string name, string description)

        {                                                       //WHY do we have unused parameters??
            foreach(Category category in _categories)
            {
                if(category.Category_ID == id)
                {
                    return View(category);
                }
            }
            return View();
        }
        public ActionResult UpdateCategorySave(int id, string name, string description)
        {
            foreach(Category category in _categories)
            {
                if(category.Category_ID == id)
                {
                    category.Category_Name = name;
                    category.Category_Description = description;
                    break;
                }
            }
            return View("GetAllTableCategories", _categories);
        }
        public ActionResult DeleteCategory(int id)
        {
            foreach (Category category in _categories)
            {
                if (category.Category_ID == id)
                {
                    _categories.Remove(category);
                    break;
                }
            }
            return View("GetAllTableCategories", _categories);
        }
    }
}
