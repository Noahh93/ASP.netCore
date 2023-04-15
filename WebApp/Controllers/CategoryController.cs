using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApp.Models;
using WebApp.Repository;

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

        public int CategoryPrice()
        {
            return 200;
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
            CategoryRepository categoryRepository = new CategoryRepository();

            List<Category> DBcategories = categoryRepository.GetAllCategories();
            return View(DBcategories);
        }
        
        public ActionResult CategoryForm()
        {
            return View();          //This method has a view that works as a form
                                    //When that form is filled it's then saved in the method below "CategorySave".
        }
        public ActionResult CategorySave(int id, string name, string description, string imagepath)
        {
            CategoryRepository DBcategory = new CategoryRepository();
            DBcategory.CreateNewCategory(id, name, description, imagepath);
            List<Category> categoryList = DBcategory.GetAllCategories();

            return View("GetAllTableCategories", categoryList);
            //Category category = new Category();
            //category.Category_ID = id;
            //category.Category_Name = name;
            //category.Category_Description = description;

            //_categories.Add(category);
            //return View("GetAllTableCategories", _categories);
        }
        public ActionResult UpdateCategory(int id)
        {
            CategoryRepository DBcategory = new CategoryRepository();
            Category categoryVariable = DBcategory.GetCategoryByID(id);


            if (categoryVariable == null)
            {
                return View();
            }
            else
            {
                return View("UpdateCategory", categoryVariable);
            }

        }
        public ActionResult UpdateCategorySave(int id, string name, string description)
        {
            CategoryRepository DBcategory = new CategoryRepository();
            DBcategory.UpdateCategory(id, name, description);
            List<Category> categoryList = DBcategory.GetAllCategories();
           
            return View("GetAllTableCategories", categoryList);
        }
        public ActionResult DeleteCategory(int id)
        {
            CategoryRepository DBcategory = new CategoryRepository();
            DBcategory.DeleteCategory(id);
            List<Category> categoryList = DBcategory.GetAllCategories();

            return View("GetAllTableCategories", categoryList);
        }
        public ActionResult SearchCategory(string categoryName)
        {
            List<Category> categories = new List<Category>();
            foreach(Category category in _categories)
            {
                if(category.Category_Name.ToLower().Contains(categoryName.ToLower()))
                {
                    categories.Add(category);
                }
            }
            ViewBag.Amount = categories.Count;
            return View("GetAllTableCategories", categories);
        }
    }
}
