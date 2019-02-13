using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTradingSystem.DataLayer;
using CarTradingSystem.ViewModel;
using CarTradingSystem.Models;
using System.IO;

namespace CarTradingSystem.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            ModelAdd CarModel = new ModelAdd();
            var comlist = CarTradingDBAccess.GetCompanyList();
            if (comlist != null)
            {
                CarModel.CompanyList = comlist.Select(x => new SelectListItem
                {
                    Value = x.CompanyID.ToString(),
                    Text = x.CompanyName
                });
            }
            var Brands = CarTradingDBAccess.GetBrandList();
            if (Brands != null)
            {
                CarModel.BrandList = Brands.Select(x => new SelectListItem
                {
                    Value = x.BrandID.ToString(),
                    Text = x.BrandName
                });
            }
            var Years = new List<int>();
            int currentYear = System.DateTime.Now.Year;
            for (int i = 0; i < 50; i++)
            {
                Years.Add(currentYear - i);
            }
            CarModel.YearList = Years.Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            });

            var bodyType = CarTradingDBAccess.GetBodyTypeList();
            if (bodyType != null)
            {
                CarModel.BodyStyleList = bodyType.Select(x => new SelectListItem
                {
                    Value = x.BodyTypeID.ToString(),
                    Text = x.BodyTypeName
                });
            }
            return View(CarModel);
        }
        [HttpPost]
        public ActionResult Add(ModelAdd request)
        {
            if (ModelState.IsValid)
            {
                var modelcheck = CarTradingDBAccess.GetModelByName(request.ModelName, request.BrandID);
                if (modelcheck != null)
                {
                    ModelState.AddModelError("ModelName", "Model Name Already Exist");
                }
                else
                {
                    Model model = ViewToDataModel(request);
                    if (CarTradingDBAccess.AddModel(model))
                    {
                        var Addedmodel = CarTradingDBAccess.GetModelByName(request.ModelName, request.BrandID);
                        return RedirectToAction("AddModelImage", new { ModelID = Addedmodel.ModelID });
                    }
                }

            }
            var comlist = CarTradingDBAccess.GetCompanyList();
            if (comlist != null)
            {
                request.CompanyList = comlist.Select(x => new SelectListItem
                {
                    Value = x.CompanyID.ToString(),
                    Text = x.CompanyName
                });
            }
            var Brands = CarTradingDBAccess.GetBrandList();
            if (Brands != null)
            {
                request.BrandList = Brands.Select(x => new SelectListItem
                {
                    Value = x.BrandID.ToString(),
                    Text = x.BrandName
                });
            }
            var bidyType = CarTradingDBAccess.GetBodyTypeList();
            if (bidyType != null)
            {
                request.BodyStyleList = bidyType.Select(x => new SelectListItem
                {
                    Value = x.BodyTypeID.ToString(),
                    Text = x.BodyTypeName
                });
            }
            var Years = new List<int>();
            int currentYear = System.DateTime.Now.Year;
            for (int i = 0; i < 50; i++)
            {
                Years.Add(currentYear - i);
            }
            request.YearList = Years.Select(x => new SelectListItem
            {
                Value = x.ToString(),
                Text = x.ToString()
            });
            return View(request);
        }

        public ActionResult List()
        {
            var allcars = CarTradingDBAccess.GetAllCars();
            return View(allcars);
        }

        public ActionResult Details(int id)
        {
            var cardetails = CarTradingDBAccess.GetModelByID(id);

            ModelDetailsImagesView modeldetails = new ModelDetailsImagesView();

            var companyinfo = CarTradingDBAccess.GetCompanyIDByBrandId(cardetails.BrandID);
            if (companyinfo != null)
                modeldetails.Country = companyinfo.Company.Country;

            modeldetails.ModelID = cardetails.ModelID;
            modeldetails.ModelName = cardetails.ModelName;
            modeldetails.BrandName = cardetails.Brand.BrandName;
            modeldetails.YearOfRelease = cardetails.YearOfRelease;
            modeldetails.Price = cardetails.Price;
            modeldetails.BodyStyleName = cardetails.BodyType.BodyTypeName;
            modeldetails.EngineType = cardetails.EngineType;
            modeldetails.Displacement = cardetails.Displacement;
            modeldetails.Power = cardetails.Power;
            modeldetails.Torque = cardetails.Torque;
            modeldetails.Transmission = cardetails.Transmission;
            modeldetails.DriveTrain = cardetails.DriveTrain;
            modeldetails.NumberOfGears = cardetails.NumberOfGears;
            modeldetails.NumberofCylinders = cardetails.NumberofCylinders;
            modeldetails.Performance0To100Kmph = cardetails.Performance0To100Kmph;
            modeldetails.MaximumSpeed = cardetails.MaximumSpeed;
            modeldetails.FuelTankCapacity = cardetails.FuelTankCapacity;
            modeldetails.BodyColor = cardetails.BodyColor;
            modeldetails.Length = cardetails.Length;
            modeldetails.Width = cardetails.Width;
            modeldetails.Height = cardetails.Height;
            modeldetails.Wheelbase = cardetails.Wheelbase;
            modeldetails.GrossWeight = cardetails.GrossWeight;
            modeldetails.SeatingCapacity = cardetails.SeatingCapacity;
            modeldetails.WheelType = cardetails.WheelType;
            modeldetails.FrontTyreSize = cardetails.FrontTyreSize;
            modeldetails.RearTyreSize = cardetails.RearTyreSize;
            modeldetails.FrontBrakeType = cardetails.FrontBrakeType;
            modeldetails.RearBrakeType = cardetails.RearBrakeType;
            modeldetails.FrontSuspension = cardetails.FrontSuspension;
            modeldetails.RearSuspension = cardetails.RearSuspension;
            modeldetails.PowerSteering = cardetails.PowerSteering;
            modeldetails.SteeringType = cardetails.SteeringType;
            modeldetails.NotAvailable = cardetails.NotAvailable;

            List<string> imagelist = new List<string>();

            var carimages = CarTradingDBAccess.GetModelImagesByID(id);

            foreach (var image in carimages)
            {
                if (image.ThumbImage == true)
                    modeldetails.ThumbImage = image.ImagePath;
                else if(image.CardImage==false && image.ThumbImage ==false)
                  imagelist.Add(image.ImagePath);
            }

            modeldetails.carimages = imagelist;
            return View(modeldetails);

        }
        private Model ViewToDataModel(ModelAdd modelAdd)
        {
            Model retModel = new Model();
            retModel.BodyColor = modelAdd.BodyColor;
            retModel.BodyStyle = modelAdd.BodyStyle;
            retModel.BrandID = modelAdd.BrandID;
            retModel.Displacement = modelAdd.Displacement;
            retModel.DriveTrain = modelAdd.DriveTrain;
            retModel.EngineType = modelAdd.EngineType;
            retModel.FrontBrakeType = modelAdd.FrontBrakeType;
            retModel.FrontSuspension = modelAdd.FrontSuspension;
            retModel.FrontTyreSize = modelAdd.FrontTyreSize;
            retModel.FuelTankCapacity = modelAdd.FuelTankCapacity;
            retModel.GrossWeight = modelAdd.GrossWeight;
            retModel.Height = modelAdd.Height;
            retModel.Length = modelAdd.Length;
            retModel.MaximumSpeed = modelAdd.MaximumSpeed;
            retModel.ModelName = modelAdd.ModelName;
            retModel.NotAvailable = false;
            retModel.NumberofCylinders = modelAdd.NumberofCylinders;
            retModel.NumberOfGears = modelAdd.NumberOfGears;
            retModel.Performance0To100Kmph = modelAdd.Performance0To100Kmph;
            retModel.Power = modelAdd.Power;
            retModel.PowerSteering = modelAdd.PowerSteering;
            retModel.Price = modelAdd.Price;
            retModel.RearBrakeType = modelAdd.RearBrakeType;
            retModel.RearSuspension = modelAdd.RearSuspension;
            retModel.RearTyreSize = modelAdd.RearTyreSize;
            retModel.SeatingCapacity = modelAdd.SeatingCapacity;
            retModel.SteeringType = modelAdd.SteeringType;
            retModel.Torque = modelAdd.Torque;
            retModel.Transmission = modelAdd.Transmission;
            retModel.Wheelbase = modelAdd.Wheelbase;
            retModel.WheelType = modelAdd.WheelType;
            retModel.Width = modelAdd.Width;
            retModel.YearOfRelease = modelAdd.YearOfRelease;
            return retModel;
        }

        public ActionResult AddModelImage(int ModelID)
        {
            var model = CarTradingDBAccess.GetModelByID(ModelID);
            CarImageAdd VModel = new CarImageAdd();
            if (model != null)
            {
                VModel.ModelName = model.ModelName;
                VModel.ModelID = model.ModelID;
                VModel.Brand = model.Brand.BrandName;
            }
            return View(VModel);
        }
        [HttpPost]
        public ActionResult AddModelImage(int ModelID, HttpPostedFileBase thumb, HttpPostedFileBase cardimage, HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3, HttpPostedFileBase img4, HttpPostedFileBase img5, HttpPostedFileBase img6, HttpPostedFileBase img7, HttpPostedFileBase img8)
        {

            CarTradingDBAccess.DeleteCarImages(ModelID);


            if (thumb != null && thumb.ContentLength > 0)
            {
                var fileName = "ModelID-" + ModelID + "_ThumbImage.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                thumb.SaveAs(path);
               
                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddThumbImage(ModelID, DBPath);
            }

            if (cardimage != null && cardimage.ContentLength > 0)
            {
                var fileName = "ModelID-" + ModelID + "_CardImage.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                thumb.SaveAs(path);

                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddCardImage(ModelID, DBPath);
            }

            if (img1 != null && img1.ContentLength > 0)
            {
                var fileName = "ModelID-" + ModelID + "_1.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                img1.SaveAs(path);
                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddCarImage(ModelID, DBPath);
            }
            if (img2 != null && img2.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(img1.FileName);
                var fileName = "ModelID-" + ModelID + "_2.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                img2.SaveAs(path);
                string DBPath = "/Resource/CarImages/"+ fileName;
                CarTradingDBAccess.AddCarImage(ModelID, DBPath);
            }
            if (img3 != null && img3.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(img1.FileName);
                var fileName = "ModelID-" + ModelID + "_3.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                img3.SaveAs(path);
                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddCarImage(ModelID, DBPath);
            }
            if (img4 != null && img4.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(img1.FileName);
                var fileName = "ModelID-" + ModelID + "_4.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                img4.SaveAs(path);
                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddCarImage(ModelID, DBPath);
            }
            if (img5 != null && img5.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(img1.FileName);
                var fileName = "ModelID-" + ModelID + "_5.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                img5.SaveAs(path);
                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddCarImage(ModelID, DBPath);
            }
            if (img6 != null && img6.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(img1.FileName);
                var fileName = "ModelID-" + ModelID + "_6.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                img6.SaveAs(path);
                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddCarImage(ModelID, DBPath);
            }
            if (img7 != null && img7.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(img1.FileName);
                var fileName = "ModelID-" + ModelID + "_7.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                img7.SaveAs(path);
                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddCarImage(ModelID, DBPath);
            }
            if (img8 != null && img8.ContentLength > 0)
            {
                //var fileName = Path.GetFileName(img1.FileName);
                var fileName = "ModelID-" + ModelID + "_8.jpg";
                var path = Path.Combine(Server.MapPath("~/Resource/CarImages"), fileName);
                img8.SaveAs(path);
                string DBPath = "/Resource/CarImages/" + fileName;
                CarTradingDBAccess.AddCarImage(ModelID, DBPath);
            }
            return View();
        }
    }
}