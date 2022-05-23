using HydroGarden.Models;
using HydroGarden.Services;
using Microsoft.AspNetCore.Mvc;

namespace HydroGarden.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();

            SecurityServices security = new SecurityServices();
            security.loadProducts();
            productList = Admin.getListOfProducts();
            

            return View(productList);
        }

        

        public IActionResult AddToCart(int productID, decimal Qty)
        {
            CartItem cartItem = new CartItem();
            cartItem.ProductID = productID;
            cartItem.Qty = Qty;
            Admin.getCart().AddToCart(cartItem);
            return RedirectToAction("Index");
        }
        
        public IActionResult SubmitOrderPage()
        {
            return View(Admin.getCart().Items);
        }

        public IActionResult ProcessOrder()
        {
            //Take order and cust information
            //Currently, Cust is required to be logged in to place order
            //Create order object
            //Add to db
            //Update cust profile of list of orders
            return RedirectToAction("Index");
        }

    }
}
