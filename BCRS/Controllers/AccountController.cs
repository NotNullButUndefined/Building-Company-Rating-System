using BCRS.Models;
using DAL.Entities;
using DAL.Repositories;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        UserRepository userRepository = new UserRepository();
        // GET: UserReg
        public ActionResult Index()
        {
            //IRepository<User> repos = new Repository<User>();
           // User[] usersList = repos.GetAll();
            return View("~/Views/Home/Index.cshtml");
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
                userRepository.Add(userAccount);
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