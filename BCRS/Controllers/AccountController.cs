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
    public interface ICookie
    {
        void SetCookie(string userName, bool remember);
    }

    public class Cookie : ICookie
    {
        public void SetCookie(string userName, bool remember)
        {
            FormsAuthentication.SetAuthCookie(userName, remember);
        }
    }

    public class AccountController : Controller
    {
        IUserService _userService;
        ICookie _cookie;

        public AccountController(IUserService userService,
                                 ICookie cookie)
        {
            _userService = userService;
            _cookie = cookie;
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
                    _cookie.SetCookie(user.Email, user.RememberMe);
                    return View("UserPage");
                }
                else
                {
                    ModelState.AddModelError("incorrect login", "Login data is incorrect!");
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