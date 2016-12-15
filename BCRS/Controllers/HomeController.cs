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
        IRepository<Company> reposCompany;
        IRepository<Building> reposBuilding;

        public HomeController(IRepository <Company>_reposComp, IRepository<Building> _reposBuilding){
            reposCompany = _reposComp;
            reposBuilding = _reposBuilding;
        }

        public HomeController()
        {

        }

       
        public ActionResult Index()
        {
            reposCompany = new Repository<Company>();
            Company[] arr = reposCompany.GetAll();
            return View(arr.OfType<Company>().ToList());
        }

        
        public ActionResult Buildings()
        {
            reposBuilding = new Repository<Building>();
            Building[] arr = reposBuilding.GetAll();
            return View(arr.OfType<Company>().ToList());
        }
	}
}