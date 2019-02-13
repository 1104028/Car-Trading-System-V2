using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTradingSystem.DataLayer;
using CarTradingSystem.Models;
using CarTradingSystem.ViewModel;

namespace CarTradingSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomePage index = new HomePage();

            var bestcarlist = CarTradingDBAccess.GeAllBestSellerCar();

            List<BestSellingView> list = new List<BestSellingView>();

            if(bestcarlist!=null)
            {
                foreach (var best in bestcarlist)
                {
                    list.Add(new BestSellingView()
                    {
                        ModelID = best.ModelID,
                        ModelName = best.Model.ModelName,
                        Price = best.Model.Price,
                        BodyStyle = CarTradingDBAccess.GetBodyStyleNameByBodyId(best.Model.BodyStyle),
                        CardImage = CarTradingDBAccess.GetCarCardImageByModelId(best.ModelID)
                    });
                }
            }
            
            index.bestsellerlist = list;

            var latestcarlist = CarTradingDBAccess.GeAllLatestCar();

            List<BestSellingView> latestlist = new List<BestSellingView>();

            if (latestcarlist != null)
            {
                foreach (var best in latestcarlist)
                {
                    latestlist.Add(new BestSellingView()
                    {
                        ModelID = best.ModelID,
                        ModelName = best.Model.ModelName,
                        Price = best.Model.Price,
                        BodyStyle = CarTradingDBAccess.GetBodyStyleNameByBodyId(best.Model.BodyStyle),
                        CardImage = CarTradingDBAccess.GetCarCardImageByModelId(best.ModelID)
                    });
                }
            }
            index.latestcarlist = latestlist;
            return View(index);
        }

        public ActionResult Buy(int? CompanyID, int? BodyType, int? YearMin, int? YearMax, int? PriceMin, int? PriceMax)
        {
            BuyViewModel Request = new BuyViewModel();
            List<Model> ModelList = new List<Model>();
            List<int> CarModelID = new List<int>();
            CarModelID = CarTradingDBAccess.GetAllAvailableCarID();
            if (CompanyID != null)
            {
                var CarID = CarTradingDBAccess.GetCarIDByCompanyID((int)CompanyID);
                if (CarID != null)
                    CarModelID = CarModelID.Intersect(CarID).ToList();
            }
            if (BodyType != null)
            {
                var CarID = CarTradingDBAccess.GetCarIDByBodyTypeID((int)BodyType);
                if (CarID != null)
                    CarModelID = CarModelID.Intersect(CarID).ToList();
            }
            if (YearMin != null && YearMax != null)
            {
                var CarID = CarTradingDBAccess.GetCarIDByYearRange((int)YearMin, (int)YearMax);
                if (CarID != null)
                    CarModelID = CarModelID.Intersect(CarID).ToList();
            }

            if (PriceMin != null && PriceMax != null)
            {
                var CarID = CarTradingDBAccess.GetCarIDByPriceRange((int)PriceMin, (int)PriceMax);
                if (CarID != null)
                    CarModelID = CarModelID.Intersect(CarID).ToList();
            }
            var Company = CarTradingDBAccess.GetCompanyList();
            List<CompanyList> ComapanyViewList = new List<CompanyList>();

            if (Company != null)
            {
                foreach (var Com in Company)
                {
                    int count = CarTradingDBAccess.GetCarNumberByCompany(Com.CompanyID);
                    ComapanyViewList.Add(new CompanyList
                    {
                        CompanyID = Com.CompanyID,
                        CompanyName = Com.CompanyName,
                        NumberOfCar = count
                    });
                }
            }
            Request.CompanyList = ComapanyViewList;
            Request.CurrentYear = System.DateTime.UtcNow.Year;
            Request.CompanyID = CompanyID;
            Request.PriceMax = PriceMax;
            Request.PriceMin = PriceMin;
            Request.YearMax = YearMax;
            Request.YearMin = YearMin;
            Request.BodyType = BodyType;
            var BodyStyles = CarTradingDBAccess.GetBodyTypeList();
            List<BodyStyleList> BodyStyleView = new List<BodyStyleList>();
            if (BodyStyles != null)
            {
                foreach (var body in BodyStyles)
                {
                    BodyStyleView.Add(new BodyStyleList
                    {
                        BodyTypeID = body.BodyTypeID,
                        BodyTypeName = body.BodyTypeName
                    });
                }
            }
            Request.BodyList = BodyStyleView;
            
            Request.SearchList = CardViewFormat(CarModelID);
            return View(Request);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult CarDetails(int CarID)
        {
            var cardetails = CarTradingDBAccess.GetModelByID(CarID);

            ModelDetailsImagesView modeldetails = new ModelDetailsImagesView();

            if(cardetails!=null)
            {
                var companyinfo = CarTradingDBAccess.GetCompanyIDByBrandId(cardetails.BrandID);
                if(companyinfo != null)
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
            }
           

            List<string> imagelist = new List<string>();

            var carimages = CarTradingDBAccess.GetModelImagesByID(CarID);

            foreach (var image in carimages)
            {
                if (image.ThumbImage == true)
                    modeldetails.ThumbImage = image.ImagePath;
                else if (image.CardImage == false && image.ThumbImage == false)
                    imagelist.Add(image.ImagePath);
            }

            modeldetails.carimages = imagelist;
            return View(modeldetails);
        }

        public ActionResult GetQuotaion(int CarID)
        {
            var Model = CarTradingDBAccess.GetModelByID(CarID);
            if (Model == null)
            {
                return RedirectToAction("ResourceNotFound");
            }
            QuotationViewModel Quotation = new QuotationViewModel();
            #region Innitialisation
            List<Country> CountryList = new List<Country>();
            var country = CarTradingDBAccess.GetCountryList();
            if (country != null)
                CountryList = country;
            Quotation.CountryList = CountryList.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.CountryID.ToString()
            });
            var SeaPorts = CarTradingDBAccess.GetSeaPortList();
            List<SeaPort> SeaPortList = new List<SeaPort>();
            if (SeaPorts != null)
                SeaPortList = SeaPorts;
            Quotation.SeaPortList = SeaPortList.Select(x => new SelectListItem
            {
                Text = x.SerPortName + "(" + x.SerPortCode + ")",
                Value = x.SeaPortID.ToString()
            });
            Quotation.DeliveryOptions = new List<SelectListItem>()
            {

               new SelectListItem() {Text="Self", Value="1"},
               new SelectListItem() { Text="Company", Value="2"}

            };
            #endregion

            Quotation.ThumbInfo = ThumbViewFormat(CarID);
            Quotation.ModelID = CarID;
            return View(Quotation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetQuotaion(QuotationViewModel request)
        {
            #region Innitialisation
            List<Country> CountryList = new List<Country>();
            var country = CarTradingDBAccess.GetCountryList();
            if (country != null)
                CountryList = country;
            request.CountryList = CountryList.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.CountryID.ToString()
            });
            var SeaPorts = CarTradingDBAccess.GetSeaPortList();
            List<SeaPort> SeaPortList = new List<SeaPort>();
            if (SeaPorts != null)
                SeaPortList = SeaPorts;
            request.SeaPortList = SeaPortList.Select(x => new SelectListItem
            {
                Text = x.SerPortName + "(" + x.SerPortCode + ")",
                Value = x.SeaPortID.ToString()
            });
            request.DeliveryOptions = new List<SelectListItem>()
            {

               new SelectListItem() {Text="Self", Value="1"},
               new SelectListItem() { Text="Company", Value="2"}

            };
            #endregion
            Order NewOrder = new Order();
            if (ModelState.IsValid)
            {
                NewOrder.CustomerAddress = request.Address;
                NewOrder.CustomerContactNumber = request.ContactNumber;
                NewOrder.CustomerEmail = request.Email;
                NewOrder.CustomerName = request.FullName;
                if(request.DeliveryAddress==null)
                  NewOrder.DeliveryAddress = "Self";
                else
                  NewOrder.DeliveryAddress = request.DeliveryAddress;

                NewOrder.ModelID = request.ModelID;
                if(request.SeaPortID==null)
                {
                    var otherseaportid = CarTradingDBAccess.GetOtherSeaPortId();
                    NewOrder.PortID = otherseaportid;
                }
                else
                NewOrder.PortID = (int)request.SeaPortID;

                NewOrder.OtherSeaport = request.SeaPortName;
                NewOrder.OtherCountryName = request.CountryName;

                ModelState.Clear();

                if (CarTradingDBAccess.AddQutetion(NewOrder))
                {
                    ViewBag.message = "Your qutetion request has been added successfully!! Our team will contact with you Soon";
                }
                else
                {
                    ViewBag.message = "Please try again later";
                }
            }
            request.ThumbInfo = ThumbViewFormat(request.ModelID);
            request.ModelID = request.ModelID;
           
            return View(request);
        }


        public ActionResult Paybill()
        {
            return View();
        }

        public ActionResult BankTransaction()
        {
            BankPayAdd newRequ = new BankPayAdd();
            newRequ.Date = System.DateTime.UtcNow.Date;
            return View(newRequ);
        }
        [HttpPost]
        public ActionResult BankTransaction(BankPayAdd request, HttpPostedFileBase BankReceipt)
        {
            if (ModelState.IsValid)
            {
                var order = CarTradingDBAccess.GetInvoiceByNo(request.InvoiceNo);
                if (order == null)
                {
                    ModelState.AddModelError("InvoiceNo", "Invoice No not fount!!! Please place qutetion request first");
                    return View();
                }
                else
                {
                    BankPay bankPay = new BankPay();
                    bankPay.AccountName = request.AccountName;
                    bankPay.AccountNumber = request.AccountNumber;
                    bankPay.Amount = request.Amount;
                    bankPay.BankIdentifierCode = request.BankIdentifierCode;
                    bankPay.BankName = request.BankName;
                    bankPay.BranchName = request.BranchName;
                    bankPay.Date = request.Date;
                    bankPay.OrderInvoiceID = order.OrderInvoiceID;
                    if (BankReceipt != null && BankReceipt.ContentLength > 0)
                    {
                        var fileName = "Order_ID-" + order.OrderInvoiceID + "_BankReceipt.jpg";
                        var path = Path.Combine(Server.MapPath("~/Resource/BankReceipt"), fileName);
                        BankReceipt.SaveAs(path);

                        string DBPath = "/Resource/BankReceipt/" + fileName;
                        bankPay.BankReciptImage = DBPath;
                    }
                    if (CarTradingDBAccess.AddBankPay(bankPay))
                    {
                        ViewBag.message = "Our team will contact with you soon";
                    }
                    else
                    {
                        ViewBag.message = "Please try again later";
                    }
                }
            }
            return View();
        }

        private List<CardViewModel> CardViewFormat(List<int> ModelID)
        {
            List<CardViewModel> ret = new List<CardViewModel>();
            if (ModelID != null)
            {
                ModelID = ModelID.OrderByDescending(i => i).Take(50).ToList();
                foreach (int id in ModelID)
                {
                    var Model = CarTradingDBAccess.GetModelByID(id);
                    if(Model!=null)
                    {
                        CardViewModel CardView = new CardViewModel();
                        CardView.BodyType = Model.BodyType.BodyTypeName;
                        CardView.CarID = Model.ModelID;
                        CardView.ModelName = Model.ModelName;
                        CardView.Price = Model.Price;
                        CardView.CarImage = CarTradingDBAccess.GetCardImage(Model.ModelID);
                        ret.Add(CardView);
                    }
                   

                }
            }
            return ret;
        }

        private ThumbImageViewModel ThumbViewFormat(int ModelID)
        {
            ThumbImageViewModel ThumbView = new ThumbImageViewModel();
            var Model = CarTradingDBAccess.GetModelByID(ModelID);
            if (Model != null)
            {
                var companyinfo = CarTradingDBAccess.GetCompanyIDByBrandId(Model.BrandID);
                if (companyinfo != null)
                    ThumbView.Country = companyinfo.Company.Country;

                ThumbView.CarID = Model.ModelID;
                ThumbView.ModelName = Model.ModelName;
                ThumbView.Price = Model.Price;
                ThumbView.CarImage = CarTradingDBAccess.GetThumbImage(Model.ModelID);
                ThumbView.YearofRelease = Model.YearOfRelease;
            }

            return ThumbView;
        }

        public JsonResult VerificationCode(string email)
        {

            Random generator = new Random();
            String verificationCode = generator.Next(0, 999999).ToString("D6");
            MailClient mailClient = new MailClient();
            EmailVerificationCode emailVerificationCode = new EmailVerificationCode();
            var EmailInfo = CarTradingDBAccess.GetEmail();
            if(EmailInfo!=null)
            {
                mailClient.clientAddr = EmailInfo.SMTPclientAddr;
                mailClient.clientPort = EmailInfo.SMTPclientPort;
                mailClient.from = EmailInfo.hostID;
                mailClient.to = email;
                mailClient.Subject = "Car trading system-Email verification";
                mailClient.Body = "Your car trading system email verification code is" + verificationCode + "" +
                   " If it is not you please ignore it \n" +
                   "  Thank you";
                mailClient.hostID = EmailInfo.hostID;
                mailClient.hostPass = EmailInfo.hostPass;
              
                emailVerificationCode.Code = verificationCode;
                emailVerificationCode.email = email;
                try
                {
                    mailClient.SendMail();
                    emailVerificationCode.EmailSend = true;
                }
                catch (Exception e)
                {
                    emailVerificationCode.EmailSend = false;
                }
            }
            else
            {
                emailVerificationCode.EmailSend = false;
            }
           

            return Json(emailVerificationCode, JsonRequestBehavior.AllowGet);
        }
    }
}