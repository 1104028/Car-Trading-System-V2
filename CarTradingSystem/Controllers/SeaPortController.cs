using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTradingSystem.DataLayer;
using CarTradingSystem.ViewModel;
using CarTradingSystem.Models;
namespace CarTradingSystem.Controllers
{
    public class SeaPortController : Controller
    {
        // GET: SeaPort
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            SeaPortAdd seaport = new SeaPortAdd();
            var comlist = CarTradingDBAccess.GetCountryList();
            if (comlist != null)
            {
                seaport.CountryList = comlist.Select(x => new SelectListItem
                {
                    Value = x.CountryID.ToString(),
                    Text = x.CountryName
                });
            }
            return View(seaport);
        }
        [HttpPost]
        public ActionResult Add(SeaPortAdd brand)
        {
            var comlist = CarTradingDBAccess.GetCountryList();

            if (ModelState.IsValid)
            {
                SeaPort NewBrand = new SeaPort
                {
                    SerPortCode = brand.SerPortCode,
                    SerPortName = brand.SerPortName,
                    CountryID=brand.CountryID
                };
                if (CarTradingDBAccess.AddSeaPort(NewBrand))
                {
                    ViewBag.message = "Sea Port has been added successfully";
                    SeaPortAdd tem = new SeaPortAdd();
                   
                    if (comlist != null)
                    {
                        tem.CountryList = comlist.Select(x => new SelectListItem
                        {
                            Value = x.CountryID.ToString(),
                            Text = x.CountryName
                        });
                    }
                    ModelState.Clear();
                    return View(tem);
                }
                else
                {
                    ViewBag.message = "Operation Failed!!";
                }
            }
            if (comlist != null)
            {
                brand.CountryList = comlist.Select(x => new SelectListItem
                {
                    Value = x.CountryID.ToString(),
                    Text = x.CountryName,
                    Selected = brand.CountryID == x.CountryID ? true : false
                });
            }
            return View(brand);
        }
    }
}