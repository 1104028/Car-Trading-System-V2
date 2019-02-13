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
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            BrandAdd brand = new BrandAdd();
            var comlist = CarTradingDBAccess.GetCompanyList();
            if (comlist != null)
            {
                brand.CompanyList = comlist.Select(x => new SelectListItem
                {
                    Value = x.CompanyID.ToString(),
                    Text = x.CompanyName
                });
            }
            return View(brand);
        }
        [HttpPost]
        public ActionResult Add(BrandAdd brand)
        {
            var comlist = CarTradingDBAccess.GetCompanyList();
           
            if (ModelState.IsValid)
            {
                Brand NewBrand = new Brand {
                    BrandName = brand.BrandName,
                    CompanyID=brand.CompanyID
                    };
                if (CarTradingDBAccess.AddBrand(NewBrand))
                {
                    ViewBag.message = "Brand has been added successfully";
                    BrandAdd tem = new BrandAdd();
                    if (comlist != null)
                    {
                        tem.CompanyList = comlist.Select(x => new SelectListItem
                        {
                            Value = x.CompanyID.ToString(),
                            Text = x.CompanyName,
                            Selected = brand.CompanyID == x.CompanyID ? true : false
                        });
                    }
                    return View(tem);
                }
                else
                {
                    ViewBag.message = "Operation Failed!!";
                }
            }
            if (comlist != null)
            {
                brand.CompanyList = comlist.Select(x => new SelectListItem
                {
                    Value = x.CompanyID.ToString(),
                    Text = x.CompanyName,
                    Selected = brand.CompanyID == x.CompanyID ? true : false
                });
            }
            return View(brand);
        }
    }
}