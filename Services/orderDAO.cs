using HydroGarden.Models;
using Microsoft.Data.SqlClient;

namespace HydroGarden.Services
{
    public class orderDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Submits the order to the order table and updates the cart
        /// table with the appropriate amount of products the user has 
        /// requested. 
        /// </summary>
        /// <param name="or">Order object </param>
        /// <returns>Returns a bool value indicated if the order
        ///         was successfully submitted. </returns>
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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }

            }

            return true;

        }

        /// <summary>
        /// Connects to the dbo.Orders table to retrieve all orders
        /// the current user has submitted. 
        /// </summary>
        public void GetUserOrders()
        {
            string sqlStatement = "select * from dbo.orders where custID = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int, 40).Value = Admin.custID;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Order or = new Order();
                        or.id = (int)reader["orderID"];
                        or.datePlace = Convert.ToDateTime(reader["datePlaced"]).ToString("dd/MM/yyyy");
                        or.dateScheduled = Convert.ToDateTime(reader["dateScheduled"]).ToString("dd/MM/yyyy");
                        or.isCompleted = (bool)reader["isCompleted"];
                        or.custId = Admin.custID;
                        Admin.addOrder(or);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
