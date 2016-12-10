using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;
using DAL.Entities;


namespace BCRS.Controllers
{
    public class HomeController : Controller
    {
       
        //
        // GET: /Home/
        public ActionResult Index()
        {

            IRepository<Company> repos = new Repository<Company>();
            Company[] arr = repos.GetAll();
            return View(arr.OfType<Company>().ToList());
        }
	}
}