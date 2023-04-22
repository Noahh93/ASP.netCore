using System.Data.SqlClient;
using WebApp.Models;
namespace WebApp.Repository
{
    public class CountryRepository
    {
        public List<Country> GetCountries()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Facebook;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand($"select id, _name from country", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();  //Executes for reading purpose

            List<Country> countries = new List<Country>();

            while (reader.Read())
            {
                Country country = new Country();

                country.Id = (Convert.ToInt32(reader["id"]));
                country.Name = $"{reader["_name"]}";

                countries.Add(country);
            }
            sqlConnection.Close();
            return countries;
        }
    }
}
