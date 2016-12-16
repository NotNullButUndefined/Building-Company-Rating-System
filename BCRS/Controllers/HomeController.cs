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

        public HomeController(IRepository <Company>_reposComp, IRepository<Building> _reposBuilding)
        {
            reposCompany = _reposComp;
            reposBuilding = _reposBuilding;
        }

        public HomeController()
        {
            reposCompany = new Repository<Company>();
            reposBuilding = new Repository<Building>();
        }
       
        public ActionResult Index()
        {
            reposCompany = new Repository<Company>();
            Company[] arr = reposCompany.GetAll();
            return View(Sorting(arr.OfType<Company>().ToList()));
        }

        private IEnumerable<Company> Sorting(IEnumerable<Company> list)
        {
            return list.OrderBy(s => s.Name);  
        }

        private IEnumerable<Building> Sorting(IEnumerable<Building> list)
        {
            return list.OrderBy(s => s.Name);
        }

        public ActionResult Buildings(int id)
        {
            var result = reposBuilding.GetAll().Where(building => building.CompanyId == id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Search(string searchStr)
        {


            reposCompany = new Repository<Company>();
            Company[] compArray = reposCompany.GetAll();
            List<Company> compList = compArray.ToList();
            //var results = bList.Where(b => b.Name.Contains(searchStr));
            //results.ToList();
            var companyItems = from item in compList
                               where item.Name == searchStr
                               select item;

            return View(companyItems.ToList());


        }
	}
}