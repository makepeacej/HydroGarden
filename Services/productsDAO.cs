using HydroGarden.Models;
using Microsoft.Data.SqlClient;

namespace HydroGarden.Services
{
    public class productsDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void GetProductInfo()
        {
            Admin.clearProducts();
            string sqlStatement = "SELECT * FROM Products";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.id = (int)reader["productID"];
                        product.name = (string)reader["Name"];
                        
                        
                        product.availability = (bool)reader["availability"];
                        
                        product.price = Math.Round((double)reader["price"],2);
                        Admin.addProduct(product);

                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}
