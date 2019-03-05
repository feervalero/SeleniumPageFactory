using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.XPath;

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

        public static void InsertNotFoundItem(string item, string brandCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "INSERT INTO Products(SKU,MaterialFeature,Description,BrandCode) VALUES ('" + item + "','"+item+"-x-0','not found','"+brandCode+"');";
                SqlCommand insertCommand = new SqlCommand(command, connection);
                insertCommand.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
            }
        }

        

        public static IList<ResultType> Compare()
        {
            
            IList<ResultType> datos = new List<ResultType>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "exec CompareProductsStep1 '" + Guid.NewGuid()+"'";
                SqlCommand insertCommand = new SqlCommand(command, connection);

                using (SqlDataReader result = insertCommand.ExecuteReader())
                {
                    
                    while (result.Read())
                    {
                        
                        if (result[1].ToString().Contains("-||-"))
                        {
                            ResultType singleResultType = new ResultType();
                            singleResultType.SKU = result[0].ToString();
                            singleResultType.Value = "Description";
                            singleResultType.Antes =
                                result[1].ToString().Substring(0,result[1].ToString().IndexOf("-||-"));
                            singleResultType.Despues =
                                result[1].ToString().Substring(result[1].ToString().LastIndexOf("-||-")+4);
                            datos.Add(singleResultType);
                        }

                        if (result[2].ToString().Contains("-||-"))
                        {
                            ResultType singleResultType = new ResultType();
                            singleResultType.SKU = result[0].ToString();
                            singleResultType.Value = "FeatureTitle";
                            singleResultType.Antes =
                                result[1].ToString().Substring(0, result[1].ToString().IndexOf("-||-"));
                            singleResultType.Despues =
                                result[1].ToString().Substring(result[1].ToString().LastIndexOf("-||-")+4);
                            datos.Add(singleResultType);
                        }

                        if (result[3].ToString().Contains("-||-"))
                        {
                            ResultType singleResultType = new ResultType();
                            singleResultType.SKU = result[0].ToString();
                            singleResultType.Value = "FeatureDescription";
                            singleResultType.Antes =
                                result[1].ToString().Substring(0, result[1].ToString().IndexOf("-||-"));
                            singleResultType.Despues =
                                result[1].ToString().Substring(result[1].ToString().LastIndexOf("-||-")+4);
                            datos.Add(singleResultType);
                        }

                    }
                }


                connection.Close();
                connection.Dispose();

                return datos;
            }

        }

        public static void TempToAllOk()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "exec TempToAllOk '" + Guid.NewGuid() + "'";
                SqlCommand insertCommand = new SqlCommand(command, connection);

                connection.Close();
                connection.Dispose();

            }
        }

        public static void TempToAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "exec TempToAll '" + Guid.NewGuid() + "'";
                SqlCommand insertCommand = new SqlCommand(command, connection);

                connection.Close();
                connection.Dispose();

            }
        }

        public static bool ISCountByItem(string item )
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "exec TempToAll '" + Guid.NewGuid() + "'";
                SqlCommand insertCommand = new SqlCommand(command, connection);

                connection.Close();
                connection.Dispose();

                return true;
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

        public static void InsertImage(string item, string url, int active)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand storeCommand = new SqlCommand();
                storeCommand.CommandText = "Add_Image";
                storeCommand.CommandType = CommandType.StoredProcedure;
                storeCommand.Connection = connection;

                storeCommand.Parameters.AddWithValue("@SKU", item);
                storeCommand.Parameters.AddWithValue("@ImageUrl", url);
                storeCommand.Parameters.AddWithValue("@Active", active);
                
                storeCommand.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
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
                storeCommand.Parameters.AddWithValue("@MaterialFeature", productInfo.MaterialFeature);
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
