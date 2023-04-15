using WebApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace WebApp.Repository
{
    public class CategoryRepository
    {
        public List<Category> GetAllCategories()
        {

            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select CategoryID, CategoryName, CategoryDescription, CategoryImagePath from Category", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();  //Executes for reading purpose


            List<Category> _categories = new List<Category>();

            while(reader.Read())
            {
                Category category = new Category();
                category.Category_ID = (Convert.ToInt32(reader["CategoryID"]));
                category.Category_Name = $"{reader["CategoryName"]}";
                category.Category_Description = $"{reader["CategoryDescription"]}";
                category.ImagePath = $"{reader["CategoryImagePath"]}";
                _categories.Add(category);
            }
            sqlConnection.Close();
            return _categories;
        }
        public Category GetCategoryByID(int ID)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select CategoryID, CategoryName, CategoryDescription, CategoryImagePath from Category where CategoryID = {ID}", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();  //Executes for reading purpose


            Category category = new Category();
            while (reader.Read())
            {
                category.Category_ID = Convert.ToInt32(reader["CategoryID"]);
                category.Category_Name = $"{reader["CategoryName"]}";
                category.Category_Description = $"{reader["CategoryDescription"]}";
                category.ImagePath = $"{reader["CategoryImagePath"]}";
                
            }
            sqlConnection.Close();

            return category;
        }
        public List<Category> CreateNewCategory(int CategoryID, string CategoryName, string CategoryDescription, string CategoryImagePath)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"insert into Category (CategoryID, CategoryName, CategoryDescription, CategoryImagePath) values ({CategoryID},'{CategoryName}','{CategoryDescription}','{CategoryImagePath}')", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery(); //Executes for saving purpose
            sqlConnection.Close();

            List<Category> categories = new List<Category>();
            Category category = new Category();

            category.Category_ID = CategoryID;
            category.Category_Name = CategoryName;
            category.Category_Description = CategoryDescription;
            category.ImagePath = CategoryImagePath;

            categories.Add(category);
            return categories;
        }
        public bool DeleteCategory(int id)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"delete from Category where CategoryID = {id}", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery(); //Executes for saving purpose
            sqlConnection.Close();
            return true;
        }
        public bool UpdateCategory(int id, string name, string description)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"update Category set CategoryName = '{name}', CategoryDescription = '{description}' where CategoryID = {id}", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery(); //Executes for saving purpose
            sqlConnection.Close();
            return true;
        }
        public bool SearchProduct()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select CategoryID, CategoryName, CategoryDescription, CategoryImagePath from Category", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();  //Executes for reading purpose



            return true;
        }
    }
    
}
