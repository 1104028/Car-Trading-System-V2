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
    public class BestSellerController : Controller
    {
        // GET: BestSeller
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
                BestSellingCar car = new BestSellingCar();
                car.ModelID = best.ModelId;

                if (CarTradingDBAccess.AddBestSellingCar(car))
                {
                    ViewBag.success = "Best Selling Car Has Been Added Successfully";
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
            BestSellingUpdate updateentry = new BestSellingUpdate();

            updateentry.BestSellingCarID = id;

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

            var bestcardetails = CarTradingDBAccess.GetBestCarDetailsByBestId(id);

            if (bestcardetails != null)
            {
                updateentry.ModelId = bestcardetails.ModelID;
            }

            return View(updateentry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(BestSellingUpdate updateentry)
        {
            if (ModelState.IsValid)
            {
                BestSellingCar update = new BestSellingCar();
                update.BestSellingCarID = updateentry.BestSellingCarID;
                update.ModelID = updateentry.ModelId;

                if (CarTradingDBAccess.UpdateBestSellingCar(update))
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

        public JsonResult BrandList(int CompanyId)
        {
            var selectList = new List<SelectListItem>();
            var brandinfo = CarTradingDBAccess.GetBrandListByCompanyID(CompanyId);

            if (brandinfo != null)
            {
                foreach (var brand in brandinfo)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = brand.BrandID.ToString(),
                        Text = brand.BrandName,

                    });
                }
            }
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CarList(int BrandId)
        {
            var selectList = new List<SelectListItem>();
            var modelinfo = CarTradingDBAccess.GetAllCarsByBrandId(BrandId);

            if (modelinfo != null)
            {
                foreach (var brand in modelinfo)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = brand.ModelID.ToString(),
                        Text = brand.ModelName,

                    });
                }
            }
            return Json(selectList, JsonRequestBehavior.AllowGet);
        }
    }
}