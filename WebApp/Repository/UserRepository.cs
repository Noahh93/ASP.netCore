using System.Data.SqlClient;
using WebApp.Models;
using WebApp.Models.AssignmentInternship;

namespace WebApp.Repository
{
    public class UserRepository
    {
        public List<User> GetAllUsers()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select id, FirstName, LastName, Email, Password, image from CompanyUser", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();  //Executes for reading purpose

            List<User> users = new List<User>();
            while(reader.Read())
            {
                User user = new User();
                user.Id = Convert.ToInt32(reader["id"]);
                user.Firstname = $"{reader["FirstName"]}";
                user.Lastname = $"{reader["Lastname"]}";
                user.Email = $"{reader["Email"]}";
                user.Password = $"{reader["Password"]}";
                user.Image = $"{reader["image"]}";

                users.Add(user);
            }
            sqlConnection.Close();
            return users;
        }
        public User GetUserByEmail(string email)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select id, firstname, lastname, email, password from CompanyUser where email = '{email}'", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            User user = new User();
            while (reader.Read())
            {
                user.Email = reader["email"].ToString();
            }
            sqlConnection.Close();
            return user;
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select id, firstname, lastname, email, password from CompanyUser where email = '{email}' and password = '{password}'", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            User user = new User();
            while (reader.Read())
            {
                user.Email = reader["email"].ToString();
                user.Password = reader["password"].ToString();
            }
            sqlConnection.Close();
            return user;
        }
        public bool SaveUser(string firstname, string lastname, string email, string password, int countryid)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"insert into CompanyUser (firstname, lastname, email, password, countryid) values ('{firstname}', '{lastname}', '{email}', '{password}', {countryid})", sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery(); //Executes for saving purpose
            sqlConnection.Close();
            return true;



        }
        public List<User> SearchUserFirstLastNameEmail(string searchWord)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select Cu.id, Cu.firstname, Cu.lastname, Cu.email, Cu.password, Cu.image, Cu.countryID, c._name from CompanyUser as CU inner join Country as C on CU.CountryID = C.ID where firstname like '%{searchWord}%' or lastname like '%{searchWord}%' or email like '%{searchWord}%'", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();


            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User();

                user.Id = Convert.ToInt32(reader["id"].ToString());
                user.Firstname = reader["firstname"].ToString();
                user.Lastname = reader["lastname"].ToString();
                user.Password = reader["password"].ToString();
                user.Email = reader["email"].ToString();
                user.CountryID = Convert.ToInt32(reader["Countryid"].ToString());

                user.Country = new Country();
                user.Country.Name = reader["_name"].ToString();

                users.Add(user);
            }
            sqlConnection.Close();
            return users;
        }
    }
}
