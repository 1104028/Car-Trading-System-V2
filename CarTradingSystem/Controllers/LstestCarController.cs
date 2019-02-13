using CarTradingSystem.DataLayer;
using CarTradingSystem.Models;
using CarTradingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.Controllers
{
    public class LstestCarController : Controller
    {
        // GET: LstestCar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            BestSellingAdd best = new BestSellingAdd();

            List<Company> companylist = CarTradingDBAccess.GetCompanyList();
            if (companylist != null)
            {
                best.CompanyList = companylist.Select(x => new SelectListItem
                {
                    Value = x.CompanyID.ToString(),
                    Text = x.CompanyName
                });
            }

            List<Brand> brandlist = CarTradingDBAccess.GetBrandList();
            if (brandlist != null)
            {
                best.BrandList = brandlist.Select(x => new SelectListItem
                {
                    Value = x.BrandID.ToString(),
                    Text = x.BrandName
                });
            }

            List<Model> carlist = CarTradingDBAccess.GetAllCars();
            if (carlist != null)
            {
                best.ModelList = carlist.Select(x => new SelectListItem
                {
                    Value = x.ModelID.ToString(),
                    Text = x.ModelName
                });
            }

            return View(best);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BestSellingAdd best)
        {

            if (ModelState.IsValid)
            {
                LatestCar car = new LatestCar();
                car.ModelID = best.ModelId;

                if (CarTradingDBAccess.AddLatestCar(car))
                {
                    ViewBag.success = "Latest Car Has Been Added Successfully";
                }
                else
                {
                    ViewBag.success = "Operation Failed, Please Try Again";
                }
            }

            List<Company> companylist = CarTradingDBAccess.GetCompanyList();
            if (companylist != null)
            {
                best.CompanyList = companylist.Select(x => new SelectListItem
                {
                    Value = x.CompanyID.ToString(),
                    Text = x.CompanyName
                });
            }

            List<Brand> brandlist = CarTradingDBAccess.GetBrandList();
            if (brandlist != null)
            {
                best.BrandList = brandlist.Select(x => new SelectListItem
                {
                    Value = x.BrandID.ToString(),
                    Text = x.BrandName
                });
            }

            List<Model> carlist = CarTradingDBAccess.GetAllCars();
            if (carlist != null)
            {
                best.ModelList = carlist.Select(x => new SelectListItem
                {
                    Value = x.ModelID.ToString(),
                    Text = x.ModelName
                });
            }

            return View(best);
        }

        public ActionResult Update(int id)
        {
            LatestCarUpdate updateentry = new LatestCarUpdate();

            updateentry.LatestCarID = id;

            List<Company> companylist = CarTradingDBAccess.GetCompanyList();
            if (companylist != null)
            {
                updateentry.CompanyList = companylist.Select(x => new SelectListItem
                {
                    Value = x.CompanyID.ToString(),
                    Text = x.CompanyName
                });
            }

            List<Brand> brandlist = CarTradingDBAccess.GetBrandList();
            if (brandlist != null)
            {
                updateentry.BrandList = brandlist.Select(x => new SelectListItem
                {
                    Value = x.BrandID.ToString(),
                    Text = x.BrandName
                });
            }

            List<Model> carlist = CarTradingDBAccess.GetAllCars();
            if (carlist != null)
            {
                updateentry.ModelList = carlist.Select(x => new SelectListItem
                {
                    Value = x.ModelID.ToString(),
                    Text = x.ModelName
                });
            }

            var bestcardetails = CarTradingDBAccess.GetLatestCarByBestId(id);

            if (bestcardetails != null)
            {
                updateentry.ModelId = bestcardetails.ModelID;
            }

            return View(updateentry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(LatestCarUpdate updateentry)
        {
            if (ModelState.IsValid)
            {
                LatestCar update = new LatestCar();
                update.LatestCarID = updateentry.LatestCarID;
                update.ModelID = updateentry.ModelId;

                if (CarTradingDBAccess.UpdateLatestCar(update))
                {
                    return RedirectToAction("List");
                }

                ViewBag.success = "Operation Failed, Please try again";

            }
            List<Company> companylist = CarTradingDBAccess.GetCompanyList();
            if (companylist != null)
            {
                updateentry.CompanyList = companylist.Select(x => new SelectListItem
                {
                    Value = x.CompanyID.ToString(),
                    Text = x.CompanyName
                });
            }

            List<Brand> brandlist = CarTradingDBAccess.GetBrandList();
            if (brandlist != null)
            {
                updateentry.BrandList = brandlist.Select(x => new SelectListItem
                {
                    Value = x.BrandID.ToString(),
                    Text = x.BrandName
                });
            }

            List<Model> carlist = CarTradingDBAccess.GetAllCars();
            if (carlist != null)
            {
                updateentry.ModelList = carlist.Select(x => new SelectListItem
                {
                    Value = x.ModelID.ToString(),
                    Text = x.ModelName
                });
            }


            updateentry.ModelId = updateentry.ModelId;


            return View(updateentry);
        }

        public ActionResult List()
        {
            return View();
        }
    }
}