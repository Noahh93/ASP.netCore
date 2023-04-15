using System.Data.SqlClient;
using System.Xml.Linq;
using WebApp.Models;

namespace WebApp.Repository
{
    public class ProductRepository
    {
        public List<Product> GetAllProducts()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select ID, Name, Quantity, ImagePath, Price from Product", sqlConnection);
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

        public List<Product> CreateNewProduct(int ID, string Name, int Quantity, string ImagePath, int Price)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"insert into Product (ID, Name, Quantity, ImagePath, Price) values ({ID},'{Name}',{Quantity},'{ImagePath}',{Price})", sqlConnection);
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
    }
}



