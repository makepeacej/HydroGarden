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
                Admin.currentUserLogin = true;
                security.loadUserOrders();
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginFailure", user);
            }

        }

        public IActionResult ViewProfile()
        {
            //Search previous orders for ID that matches current customer
            //Bring order and send to this view to display order id and basic
            //details.
            
            return View(Admin.getListOfOrders());
        }

        public IActionResult Logout()
        {
            Admin.currentUserLogin = false;
            return View("Index");
        }
    }
}
