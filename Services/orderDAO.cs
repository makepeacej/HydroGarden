using HydroGarden.Models;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace HydroGarden.Services
{
    public class orderDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public bool SendOrder(Order or)
        {

            string sqlStatement1 = "Insert into dbo.Orders (custID,datePlaced,dateScheduled) " +
                "Values (@custID, @datePlaced, @dateScheduled)" +
                "Select SCOPE_IDENTITY() as [ID]";

            string sqlStatement2 = "Insert into dbo.cart (orderID, productID, quantity)" +
                "Values (@orderID, @productID, @quantity)";

         
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement1, connection);
                command.Parameters.Add("@custID", System.Data.SqlDbType.Int, 40).Value = or.custId;
                command.Parameters.Add("@datePlaced", System.Data.SqlDbType.Date, 40).Value = or.datePlace;
                command.Parameters.Add("@dateScheduled", System.Data.SqlDbType.Date, 40).Value = or.dateScheduled;


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            or.id = (int)reader.GetDecimal(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            foreach (CartItem prod in or.cart.Items)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                
                    SqlCommand command = new SqlCommand(sqlStatement2, connection);
                    command.Parameters.Add("@orderID", System.Data.SqlDbType.Int, 40).Value = or.id;
                    command.Parameters.Add("@productID", System.Data.SqlDbType.Int, 40).Value = prod.ProductID;
                    command.Parameters.Add("@quantity", System.Data.SqlDbType.Float, 40).Value = prod.Qty;

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
                
            }
            
            return true;

        }
    }
}
