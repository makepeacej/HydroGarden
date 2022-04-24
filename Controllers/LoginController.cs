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

        public IActionResult ProcessRegister(UserModel user)
        {
            //Add user to the db
            SecurityServices security = new SecurityServices();
            security.canUse(user);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityServices security = new SecurityServices();

            if (security.IsValid(user))
            {
                user.Id = Admin.custID;
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginFailure",user);
            }
            
        }
    }
}
