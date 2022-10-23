using HydroGarden.Models;

namespace HydroGarden.Services
{
    public class SecurityServices
    {

        usersDAO usersDAO = new usersDAO();
        productsDAO productsDAO = new productsDAO();
        orderDAO orderDAO = new orderDAO();

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

        public void submitOrder(Order or)
        {
            if (orderDAO.SendOrder(or))
            {
                Admin.getCart().eraseItems();
            }

        }

        public void loadUserOrders()
        {
            orderDAO.GetUserOrders();
        }
    }
}
