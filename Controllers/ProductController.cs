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
            if (Admin.currentUserLogin)
            {
                return View("OrderPage",productList);
            }
            
            return View(productList);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }
        
    }
}
