using HydroGarden.Models;

namespace HydroGarden.Services
{
    public class SecurityServices
    {
       
        usersDAO usersDAO = new usersDAO();
        productsDAO productsDAO = new productsDAO();

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

        }

        public void loadProducts()
        {
            productsDAO.GetProductInfo();
        }
    }
}
