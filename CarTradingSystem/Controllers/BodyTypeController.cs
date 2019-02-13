using CarTradingSystem.DataLayer;
using CarTradingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.Controllers
{
    public class BodyTypeController : Controller
    {
        // GET: BodyType
        public ActionResult Index()
        {
            return View();
        }
        [RBAC]
        public ActionResult Add()
        {

            return View();
        }
        [RBAC]
        [HttpPost]
        public ActionResult Add(BodyType country)
        {
            if (ModelState.IsValid)
            {
                if (CarTradingDBAccess.AddBodyStyle(country))
                {
                    ViewBag.message = "Body Type has been added successfully";
                    BodyType tem = new BodyType();
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