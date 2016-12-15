using BCRS.Models;
using DAL.Entities;
using DAL.Repositories;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;

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
        IUserRepository _userRepo;

        public ActionResult Index()
        {
            //IRepository<User> repos = new Repository<User>();
           // User[] usersList = repos.GetAll();
            return View("~/Views/Home/Index.cshtml");
        }

        private IAuthenticationManager Authentication
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.RoleId = 1;
                userAccount.Id = 1;
                _userRepo.Add(userAccount);
                SendEmailToUser(userAccount);
                ModelState.Clear();
                ViewBag.Message = userAccount.Name + " " + userAccount.Surname + " successfully register";
            }
            return View();
        }

        public void SendEmailToUser(User userAccount)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("testersender2016@gmail.com");
            mail.To.Add(new MailAddress(userAccount.Email));
            mail.Subject = "Register Test";
            mail.Body = "Register Test";

            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("testersender2016@gmail.com".Split('@')[0], "tester2016Sender");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
            mail.Dispose();
        }

        IUserService _userService;
        ICookie _cookie;

        public AccountController(IUserService userService,
                                 ICookie cookie,
                                 IUserRepository userRepo)
        {
            _userService = userService;
            _cookie = cookie;
            _userRepo = userRepo;
        }

        public AccountController()
        {
            var userRepo = new UserRepository();
            _userService = new UserService(userRepo);
            _cookie = new Cookie();
        }

        [Authorize]
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
        public ActionResult Login(LoginDto user)
        {
            if (ModelState.IsValid)
            {
                var loginResult = _userService.TryLogin(user.Email, user.Password);

                if (loginResult)
                {
                    _cookie.SetCookie(user.Email, user.RememberMe);
                    var actualUser = _userRepo.GetByEmail(user.Email);
                    var claims = new List<Claim>()
                    {
                            new Claim(ClaimTypes.NameIdentifier, actualUser.ToString()),
                            new Claim(ClaimTypes.Name, actualUser.Name),
                            new Claim(ClaimTypes.Surname, actualUser.Surname),
                            new Claim(ClaimTypes.Email, actualUser.Email)
                    };
                    
                    Authentication.SignIn(
                        new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            IsPersistent = false
                        },
                        new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie));

                    return RedirectToAction("UserPage", "Account");
                }
                else
                {
                    ModelState.AddModelError("incorrect login", "Login data is incorrect!");
                }
            }
            return View(user);
            //return false;
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("/");
        }
    }
}