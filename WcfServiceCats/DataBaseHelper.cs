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
            @"Server=tcp:catsdb.database.windows.net,1433;Initial Catalog=CatsDB;Persist Security Info=False;User ID=krimmero;Password=Leisted6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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

        public static List<string> ListAllCats()
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                
                string sql = "SELECT Name FROM cat";
                SqlCommand cmd = new SqlCommand(sql, connection);

                
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                List<string> listOfCats = new List<string>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string item = reader.GetString(reader.GetOrdinal("Name"));
                            listOfCats.Add(item);
                        }
                    }
                    
                }
                return listOfCats;

            }

        }

    }
}