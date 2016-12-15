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

        public ActionResult Buildings(int CompanyId)
        {
            //Change?
            List<Building> listBuild = new List<Building>();
            Building[] arr = reposBuilding.GetAll();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompanyId == CompanyId) listBuild.Add(arr[i]);
            }
                return View(listBuild);
        }
	}
}