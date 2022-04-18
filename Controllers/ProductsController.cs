using Microsoft.AspNetCore.Mvc;

namespace HydroGarden.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
