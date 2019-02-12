using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SharedClasses
{
    public static class DataBase
    {
        private static string connectionString {
            get { return "Server=APOL5CG8090XR8;Database=MXBrands;User Id=sa;Password = Calidad1; "; }
        }

        public static void CleanProductTable(string BrandCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "DELETE FROM Products WHERE BrandCode ='"+BrandCode+"'";
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

        public static IList<string> GetProducts(string brandCode)
        {
            IList<string> datos = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "SELECT ModelNumber FROM SKU where BrandCode = '"+brandCode+"'";
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

        public static void ExecuteNonQueryCommand(string command)
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


        public static void ExecuteProcedure(ProductDetail productInfo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand storeCommand = new SqlCommand();
                storeCommand.CommandText = "Add_Product_KAD";
                storeCommand.CommandType = CommandType.StoredProcedure;
                storeCommand.Connection = connection;

                storeCommand.Parameters.AddWithValue("@SKU", productInfo.SKU);
                storeCommand.Parameters.AddWithValue("@Description", productInfo.Description);
                storeCommand.Parameters.AddWithValue("@Price", productInfo.Price);
                storeCommand.Parameters.AddWithValue("@BrandCode", productInfo.BrandCode);
                storeCommand.Parameters.AddWithValue("@Feature", productInfo.Feature);
                storeCommand.Parameters.AddWithValue("@FeatureDescription", productInfo.FeatureDescription);
                storeCommand.Parameters.AddWithValue("@FeatureType", productInfo.FeatureType);

                storeCommand.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
            }
        }

    }
}
