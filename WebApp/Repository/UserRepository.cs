using System.Data.SqlClient;
using WebApp.Models;
namespace WebApp.Repository
{
    public class UserRepository
    {
        public List<User> GetAllUsers()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select id, FirstName, LastName, Email, Password, image from UserProfile", sqlConnection);
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
    }
}
