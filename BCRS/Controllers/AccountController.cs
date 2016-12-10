using BCRS.Models;
using DAL.Entities;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BCRS.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public AccountController()
        {

        }

        public ActionResult UserPage()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDto user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _userService.TryLogin(user.Email, user.Password);

                if (loginResult)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, user.RememberMe);
                    return View("UserPage");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}