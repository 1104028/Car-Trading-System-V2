using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarTradingSystem.Models;
namespace CarTradingSystem.DataLayer
{
    public class CarTradingDBAccess
    {
        //--------------------Admin-----------------
        #region
        public static bool AddAdmin(AdminAccount request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.AdminAcount.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsAdminExist(string UserName, string Pass)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var Admin = context.AdminAcount.Where(a => a.UserName == UserName && a.Password == Pass).FirstOrDefault();

                    return Admin != null;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
        //-------------------Company----------------
        #region
        public static bool AddCompany(Company request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.Company.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static List<Company> GetCompanyList()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var companyList = context.Company.ToList();

                    return companyList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static int GetCarNumberByCompany(int CompanyID)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    //var IDList = context.Model.Include("Brand").Where(a => a.Brand.CompanyID == companyID&& a.NotAvailable==false).ToList();
                    var IDList = context.Model.Include("Brand").Where(a => a.Brand.CompanyID == CompanyID && a.NotAvailable == false).Count();

                    return IDList;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

       
        #endregion
        //------------------Brand-------------------
        #region
        public static bool AddBrand(Brand request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.Brand.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static List<Brand> GetBrandList()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var CountryList = context.Brand.ToList();

                    return CountryList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<Brand> GetBrandListByCompanyID(int companyID)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var CountryList = context.Brand.Where(a => a.CompanyID == companyID).ToList();

                    return CountryList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Brand GetCompanyIDByBrandId(int brandid)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var brand = context.Brand.Include("Company").Where(a=>a.BrandID==brandid).SingleOrDefault();
                    if(brand!=null)
                    {
                        return brand;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        //------------------Model-------------------
        #region
        public static bool AddModel(Model request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.Model.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Model GetModelByName(string ModelName, int BrandID)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var model = context.Model.Where(a => a.ModelName == ModelName && a.BrandID == BrandID).FirstOrDefault();

                    return model;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static Model GetModelByID(int ModelID)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var model = context.Model.Include("Brand").Include("BodyType").Where(a => a.ModelID == ModelID).FirstOrDefault();

                    return model;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool AddCarImage(int modelID, string ImagePath)
        {

            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.CarImage.Add(new CarImage
                    {
                        ModelID = modelID,
                        ImagePath = ImagePath,
                        ThumbImage = false

                    });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static bool AddThumbImage(int modelID, string ImagePath)
        {

            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.CarImage.Add(new CarImage
                    {
                        ModelID = modelID,
                        ImagePath = ImagePath,
                        ThumbImage = true
                    });
                    context.SaveChanges();
                    return true;
                }
            }

            catch (Exception e)
            {
                return false;
            }

        }

        public static bool AddCardImage(int modelID, string ImagePath)
        {

            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.CarImage.Add(new CarImage
                    {
                        ModelID = modelID,
                        ImagePath = ImagePath,
                        CardImage = true
                    });
                    context.SaveChanges();
                    return true;
                }
            }

            catch (Exception e)
            {
                return false;
            }

        }
        public static List<Model> GetAllCars()
        {

            try
            {
                using (CarTrading context = new CarTrading())
                {

                    var allcars = context.Model.Include("BodyType").ToList();
                    return allcars;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static void DeleteCarImages(int modelID)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var modelid = context.CarImage.Where(a => a.ModelID == modelID).ToList();
                    if (modelid != null)
                    {
                        context.CarImage.RemoveRange(modelid);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {

            }

        }

        public static List<CarImage> GetModelImagesByID(int modelid)
        {

            try
            {
                using (CarTrading context = new CarTrading())
                {

                    var modelimages = context.CarImage.Where(a => a.ModelID == modelid).ToList();
                    return modelimages;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<Model> GetAllCarsByBrandId(int brandid)
        {

            try
            {
                using (CarTrading context = new CarTrading())
                {

                    var allcars = context.Model.Include("BodyType").Where(a => a.BrandID == brandid).ToList();
                    return allcars;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static string GetCarCardImageByModelId(int modelid)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var bodylist = context.CarImage.Where(a => a.ModelID == modelid).ToList();
                    if (bodylist != null)
                    {
                        foreach (var image in bodylist)
                        {
                            if (image.CardImage == true)
                            {
                                return image.ImagePath;
                            }
                        }
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<int> GetAllAvailableCarID()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    //var IDList = context.Model.Include("Brand").Where(a => a.Brand.CompanyID == companyID&& a.NotAvailable==false).ToList();
                    var IDList = context.Model.Include("Brand").Where(a => a.NotAvailable == false).Select(a => (int)a.ModelID).ToList();
                    return IDList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<int> GetCarIDByCompanyID(int companyID)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    //var IDList = context.Model.Include("Brand").Where(a => a.Brand.CompanyID == companyID&& a.NotAvailable==false).ToList();
                    var IDList = context.Model.Include("Brand").Where(a => a.Brand.CompanyID == companyID && a.NotAvailable == false).Select(a => (int)a.ModelID).ToList();
                    return IDList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<int> GetCarIDByYearRange(int yearMin, int YearMax)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    //var IDList = context.Model.Include("Brand").Where(a => a.Brand.CompanyID == companyID&& a.NotAvailable==false).ToList();
                    var IDList = context.Model.Include("Brand").Where(a => a.YearOfRelease >= yearMin && a.YearOfRelease <= YearMax && a.NotAvailable == false).Select(a => (int)a.ModelID).ToList();
                    return IDList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<int> GetCarIDByBodyTypeID(int BodyTypeId)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    //var IDList = context.Model.Include("Brand").Where(a => a.Brand.CompanyID == companyID&& a.NotAvailable==false).ToList();
                    var IDList = context.Model.Include("BodyType").Where(a => a.BodyType.BodyTypeID == BodyTypeId && a.NotAvailable == false).Select(a => (int)a.ModelID).ToList();
                    return IDList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<int> GetCarIDByPriceRange(int PriceMin, int PriceMax)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    //var IDList = context.Model.Include("Brand").Where(a => a.Brand.CompanyID == companyID&& a.NotAvailable==false).ToList();
                    var IDList = context.Model.Include("Brand").Where(a => a.Price >= PriceMin && a.YearOfRelease <= PriceMax && a.NotAvailable == false).Select(a => (int)a.ModelID).ToList();
                    return IDList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GetThumbImage(int ModelID)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var model = context.CarImage.Where(a => a.ModelID == ModelID && a.ThumbImage == true).FirstOrDefault().ImagePath;

                    return model;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GetCardImage(int ModelID)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var model = context.CarImage.Where(a => a.ModelID == ModelID && a.CardImage == true).FirstOrDefault().ImagePath;

                    return model;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        //----------------Country-------------------
        #region
        public static bool AddCountry(Country request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.Country.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Country> GetCountryList()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var CountryList = context.Country.ToList();

                    return CountryList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool IsCountryExist(string countryname)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var Country = context.Country.Where(a=>a.CountryName == countryname).SingleOrDefault();

                    if (Country != null)
                        return true;
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Country GetCountryInfoByCountryName(string countryname)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var Country = context.Country.Where(a => a.CountryName == countryname).SingleOrDefault();

                    if (Country != null)
                        return Country;
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
        //----------------SeaPort-------------------
        #region
        public static bool AddSeaPort(SeaPort request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.SeaPort.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<SeaPort> GetAllSeaPortByCountryId(int countryid)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                   var seaports = context.SeaPort.Where(a=>a.CountryID == countryid).ToList();

                    return seaports;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<SeaPort> GetSeaPortList()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var CountryList = context.SeaPort.ToList();

                    return CountryList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GetCountryNameBySeaPortId(int portid)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var seaport = context.SeaPort.Include("Country").Where(a => a.SeaPortID == portid).SingleOrDefault();

                    if(seaport!=null)
                      return seaport.Country.CountryName;

                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static int GetOtherSeaPortId()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var seaport = context.SeaPort.Where(a => a.SerPortName == "Other").SingleOrDefault();

                    if (seaport != null)
                        return seaport.SeaPortID;

                    return 0;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        #endregion
        //----------------BodyStyle-----------------
        #region
        public static bool AddBodyStyle(BodyType request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.BodyType.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static List<BodyType> GetBodyTypeList()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var CountryList = context.BodyType.ToList();

                    return CountryList;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string GetBodyStyleNameByBodyId(int bodyid)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var bodylist = context.BodyType.Where(a => a.BodyTypeID == bodyid).SingleOrDefault();
                    if (bodylist != null)
                        return bodylist.BodyTypeName;
                    else
                        return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        //----------------Best Selling Car ---------
        #region
        public static bool AddBestSellingCar(BestSellingCar request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.BestSellingCar.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<BestSellingCar> GeAllBestSellerCar()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var bestlist = context.BestSellingCar.Include("Model").ToList();

                    return bestlist;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool UpdateBestSellingCar(BestSellingCar request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                   var best=  context.BestSellingCar.Where(a=>a.BestSellingCarID == request.BestSellingCarID).SingleOrDefault();
                    if(best!=null)
                    {
                        best.ModelID = request.ModelID;
                        context.SaveChanges();
                        return true;
                    }

                    return false;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static BestSellingCar GetBestCarDetailsByBestId(int bestid)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var bestlist = context.BestSellingCar.Where(a=>a.BestSellingCarID==bestid).SingleOrDefault();

                    return bestlist;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        //----------------Latest Car ---------------
        #region
        public static bool AddLatestCar(LatestCar request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.LatestCar.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<LatestCar> GeAllLatestCar()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var bestlist = context.LatestCar.Include("Model").ToList();

                    return bestlist;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool UpdateLatestCar(LatestCar request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var best = context.LatestCar.Where(a => a.LatestCarID == request.LatestCarID).SingleOrDefault();
                    if (best != null)
                    {
                        best.ModelID = request.ModelID;
                        context.SaveChanges();
                        return true;
                    }

                    return false;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static LatestCar GetLatestCarByBestId(int bestid)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var bestlist = context.LatestCar.Where(a => a.LatestCarID == bestid).SingleOrDefault();

                    return bestlist;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        //----------Email---------------------------
        #region
        public static EmailInformation GetEmail()
        {
            try
            {
                using (CarTrading contex = new CarTrading())
                {
                    var email = contex.EmailInfo.FirstOrDefault();
                    return email;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool EmailUpdate(EmailInformation Email)
        {
            try
            {
                using (CarTrading contex = new CarTrading())
                {
                    var email = contex.EmailInfo.Where(a => a.EmailID_PK == Email.EmailID_PK).FirstOrDefault();
                    if (email != null)
                    {
                        email.hostID = Email.hostID;
                        email.hostPass = Email.hostPass;
                        email.SMTPclientAddr = Email.SMTPclientAddr;
                        email.SMTPclientPort = Email.SMTPclientPort;
                        contex.SaveChanges();
                    }
                    else
                    {
                        contex.EmailInfo.Add(Email);
                        contex.SaveChanges();
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
        //-----------Order/Qutetion-----------------
        #region
        public static bool AddQutetion(Order request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.Order.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Order> GetAllOrders()
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                   var orders =  context.Order.Include("Model").Include("SeaPort").Where(a=>a.OrderStatus == null).ToList();
                    return orders;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Order GetOrderDetails(int id)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    var orders = context.Order.Include("Model").Include("SeaPort").Where(a => a.OrderID == id).SingleOrDefault();
                    return orders;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        //-----------Order Invoice------------------
        #region
        public static bool AddOrderInvoice(OrderInvoice request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.OrderInvoice.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static OrderInvoice GetInvoiceByNo(string invoiceNo)
        {
            try
            {
                using (CarTrading contex = new CarTrading())
                {
                    var OrderInvoice = contex.OrderInvoice.Where(a => a.InvoiceNo == invoiceNo).FirstOrDefault();
                    return OrderInvoice;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion
        //--------------BankPay---------------------
        #region
        public static bool AddBankPay(BankPay request)
        {
            try
            {
                using (CarTrading context = new CarTrading())
                {
                    context.BankPays.Add(request);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}