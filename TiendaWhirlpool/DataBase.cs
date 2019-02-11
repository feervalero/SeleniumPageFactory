using System.Collections.Generic;
using System.Data.SqlClient;

namespace TiendaWhirlpool
{
    public static class DataBase
    {
        private static string connectionString {
            get { return "Server=APOL5CG8090XR8;Database=MXBrands;User Id=sa;Password = Calidad1; "; }
        }

        public static void CleanProductTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "DELETE FROM Products";
                SqlCommand insertCommand = new SqlCommand(command, connection);
                insertCommand.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
            }
        }

        public static void InsertNotFoundItem(string item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "INSERT INTO Products(SKU,Description) VALUES ('" + item + "','not found');";
                SqlCommand insertCommand = new SqlCommand(command, connection);
                insertCommand.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
            }
        }

        public static IList<string> GetProducts()
        {
            IList<string> datos = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "SELECT ModelNumber FROM SKU";
                SqlCommand insertCommand = new SqlCommand(command, connection);

                using (SqlDataReader result = insertCommand.ExecuteReader())
                {
                    
                    while (result.Read())
                    {
                        datos.Add(result[0].ToString());
                    }
                }
                

                connection.Close();
                connection.Dispose();

                return datos;
            }
        }

        internal static void ExecuteNonQueryCommand(string command)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand genericCommand = new SqlCommand(command,connection);
                genericCommand.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

            }
        }


    }
}
