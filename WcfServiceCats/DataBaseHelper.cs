using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WcfServiceCats
{
    public class DataBaseHelper
    {
        private static string connectionstring =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CatsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Boolean AddCat(Cat cat)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string sql = "INSERT INTO cat(Name, Breed, Age, Owner) VALUES (@name, @breed, @age, @owner)";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@name", cat.Name);
                cmd.Parameters.AddWithValue("@breed", cat.Breed);
                cmd.Parameters.AddWithValue("@age", cat.Age);
                cmd.Parameters.AddWithValue("@owner", cat.OwnersName);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            return true;


        }

        public static Boolean RemoveCat(Cat cat)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string sql = "DELETE FROM cat WHERE Name = @name";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@name", cat.Name);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public static Boolean UpdateCat(Cat cat)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                string sql = "UPDATE cat SET Age = @age, Owner = @owner WHERE Name = @name";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@name", cat.Name);
                cmd.Parameters.AddWithValue("@age", cat.Age);
                cmd.Parameters.AddWithValue("@owner", cat.OwnersName);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public static IEnumerable<Cat> ListAllCats(Cat cat)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                
                string sql = "SELECT * FROM cat WHERE Name = @name";
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@name", cat.Name);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                List<Cat> listOfCats = new List<Cat>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = reader;
                        listOfCats.Add();
                    }
                }
                

            }
            return null;

        }

    }
}