using HydroGarden.Models;
using Microsoft.Data.SqlClient;

namespace HydroGarden.Services
{
    public class usersDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        

        /// <summary>
        /// Will change in future to save user basic info and orders 
        ///     for viewing purposes. Currently will verify login 
        ///     credintials.
        /// </summary>
        /// <param name="user">user model object </param>
        /// <returns>true or false depending on success and failure</returns>
        public bool FindUserByNameAndPass(UserModel user)
        {
            bool success = false;
            String sqlStatement = "SELECT * FROM dbo.knownUsers where username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.Username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Admin.custID = reader.GetInt32(0);
                        }
                        success = true;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            
                return success;
            }



        }
    

        public void CreateUser(UserModel user)
        {
            String sqlStatement = "Insert into dbo.knownUsers (username,password,email) Values (@username, @password, @email)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.Username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 40).Value = user.Email;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
