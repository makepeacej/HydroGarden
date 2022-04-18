using HydroGarden.Models;
using HydroGarden.Services;
using Microsoft.AspNetCore.Mvc;

namespace HydroGarden.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityServices security = new SecurityServices();

            if (security.IsValid(user))
            {
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginFailure",user);
            }
            
        }
    }
}
