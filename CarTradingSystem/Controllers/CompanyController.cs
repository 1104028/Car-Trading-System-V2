using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTradingSystem.Models;
using CarTradingSystem.DataLayer;
namespace CarTradingSystem.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Company company)
        {
            if(ModelState.IsValid)
            {
                if (CarTradingDBAccess.AddCompany(company))
                {
                    ViewBag.message = "Company has been added successfully";
                    Company tem = new Company();
                    return View(tem);
                }
                else
                {
                    ViewBag.message = "Operation Failed!!";
                }
            }
            return View();
        }

    }
}