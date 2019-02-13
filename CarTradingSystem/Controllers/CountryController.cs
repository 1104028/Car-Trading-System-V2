using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTradingSystem.Models;
using CarTradingSystem.DataLayer;
namespace CarTradingSystem.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
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
        public ActionResult Add(Country country)
        {
            if (ModelState.IsValid)
            {
                if (CarTradingDBAccess.AddCountry(country))
                {
                    ViewBag.message = "Country has been added successfully";
                    Country tem = new Country();
                    return View(tem);
                }
                else
                {
                    ViewBag.message = "Operation Failed!!";
                }
            }
            return View(country);
            
        }

        public JsonResult SeaPorts(int CountryID)
        {
            var selectList = new List<SelectListItem>();
            var seaports = CarTradingDBAccess.GetAllSeaPortByCountryId(CountryID);

            if (seaports != null)
            {
                foreach (var brand in seaports)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = brand.SeaPortID.ToString(),
                        Text = brand.SerPortName,

                    });
                }
            }
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
    }
}