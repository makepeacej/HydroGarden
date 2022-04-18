using HydroGarden.Models;
using Microsoft.AspNetCore.Mvc;

namespace HydroGarden.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product{name = "Broccoli", price = 1.99, availability = true});
            return View(productList);
        }
    }
}
