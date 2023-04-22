using System.Data.SqlClient;
using System.Xml.Linq;
using WebApp.Models;
using WebApp.Models.AssignmentInternship;

namespace WebApp.Repository
{
    public class ProductRepository
    {
        public List<Product> GetAllProducts(string orderBy)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select p.id, p.name, p.Quantity, p.imagepath, p.price, p.homecategory, C.CategoryName, Co._name from Product as P inner join Category as C on C.CategoryID = P.HomeCategory inner join Country as Co on Co.id = P.HomeCountry order by price " + orderBy, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            while(reader.Read())
            {
                Product product = new Product();
                product.ID = Convert.ToInt32(reader["ID"]);
                product.Name = $"{reader["Name"]}";
                product.Quantity = Convert.ToInt32(reader["Quantity"]);
                product.ImagePath = $"{reader["ImagePath"]}";
                product.Price = Convert.ToInt32(reader["Price"]);
                product.HomeCategory = Convert.ToInt32(reader["HomeCategory"]);

                product.Category = new Category();
                product.Category.Category_Name = $"{reader["CategoryName"]}";

                product.Country = new Country();
                product.Country.Name = $"{reader["_name"]}";

                products.Add(product);
            }

            sqlConnection.Close();
            return products;
        }

        public Product GetProductByID(int id)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select ID, Name, Quantity, ImagePath, Price from Product where ID = {id}", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            Product product = new Product();

            while (reader.Read())
            {
                product.ID = Convert.ToInt32(reader["ID"]);
                product.Name = $"{reader["Name"]}";
                product.Quantity = Convert.ToInt32(reader["Quantity"]);
                product.ImagePath = $"{reader["ImagePath"]}";
                product.Price = Convert.ToInt32(reader["Price"]);
            }
            sqlConnection.Close();
            return product;
        }

        public List<Product> CreateNewProduct(int ID, string Name, int Quantity, string ImagePath, int Price, int homeCategory, int homecountry)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"insert into Product (ID, Name, Quantity, ImagePath, Price, HomeCategory, HomeCountry) values ({ID},'{Name}',{Quantity},'{ImagePath}',{Price}, {homeCategory}, {homecountry})", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery(); //Executes for saving purpose
            sqlConnection.Close();

            List<Product> products = new List<Product>();
            Product product = new Product();

            product.ID = ID;
            product.Name = Name;
            product.Quantity = Quantity;
            product.ImagePath = ImagePath;
            product.Price = Price;
            product.HomeCategory = homeCategory;
            product.HomeCountry = homecountry;

            product.Category = new Category();
            product.Category.Category_ID = homeCategory;

            product.Country = new Country();
            product.Country.Id = homecountry;

            products.Add(product);
            return products;
        }

        public bool DeleteProduct(int id)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"delete from Product where id = {id}", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery(); //Executes for saving purpose
            sqlConnection.Close();


            return true;
        }
        public bool UpdateProduct(int id, string name, int quantity, int price)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"update Product set Name = '{name}', Quantity = {quantity}, imagepath = 'Laptop.png', price = {price} where id = {id}", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery(); //Executes for saving purpose
            sqlConnection.Close();
            return true;
        }
        public bool SearchProduct()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select ID, Name, Quantity, ImagePath, Price from Product", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            return false;
        }
        public List<Product> SearchProduct(string keyword)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select id, name, quantity, imagepath, price from product where name like '%{keyword}%'", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();


            List<Product> products = new List<Product>();
            while(reader.Read())
            {
                Product product = new Product();

                product.ID = Convert.ToInt32(reader["id"]);
                product.Name = $"{reader["name"]}";
                product.Quantity = Convert.ToInt32(reader["quantity"]);
                product.ImagePath = $"{reader["imagepath"]}";
                product.Price = Convert.ToInt32(reader["price"]);

                products.Add(product);
            }
            sqlConnection.Close();
            return products;
        }
    }
}



