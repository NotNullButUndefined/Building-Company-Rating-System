using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using BCRS.Models;

namespace BCRS.Controllers
{
    public class UserProfileController : Controller
    {
        UserRepository userRepository = new UserRepository();
        // GET: UserProfile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditUserData()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GoToEdit()
        {

            return RedirectToAction("EditUserData", "UserProfile");
        }

        [HttpPost]
        public ActionResult EditUserData(UserEditDto userProfile)
        {
            User user = userRepository.GetByEmail(userProfile.Email);
            if (!string.IsNullOrEmpty(userProfile.Name))
            {
                user.Name = userProfile.Name;
            }

            if (!string.IsNullOrEmpty(userProfile.Surname))
            {
                user.Surname = userProfile.Surname;
            }
            if (!string.IsNullOrEmpty(userProfile.Password))
            {
                user.Password = userProfile.Password;
            }
            if (!string.IsNullOrEmpty(userProfile.Email))
            {
                user.Email = userProfile.Email;
            }
            if (ModelState.IsValid)
            {
                userRepository.ModifyUserData(user);
            }
            return View();
        }
    }
}