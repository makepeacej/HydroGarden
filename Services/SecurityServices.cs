using HydroGarden.Models;

namespace HydroGarden.Services
{
    public class SecurityServices
    {
       
        usersDAO usersDAO = new usersDAO();

        public SecurityServices()
        {
           
        }

        public bool IsValid(UserModel user)
        {
            return usersDAO.FindUserByNameAndPass(user);
        }

        public void canUse(UserModel user)
        {
            usersDAO.CreateUser(user);
            Console.WriteLine("Success");
            Console.WriteLine("username: " + user.Username);

        }
    }
}
