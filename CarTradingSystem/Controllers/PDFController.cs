using CarTradingSystem.DataLayer;
using CarTradingSystem.Models;
using CarTradingSystem.ViewModel;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.Controllers
{
    public class PDFController : Controller
    {
        // GET: PDF
        public ActionResult Index()
        {

            return View();

        }

        public ActionResult GetSamples()
        {
            Model invoice = new Model();

            var allcars = CarTradingDBAccess.GetAllCars();
            return View(allcars);

        }

        public ActionResult GeneratePDF(string invoiceno, int Orderid, double BasePrice, double SeaPortCost, double ShiftingCost, double VAT)
        {

            SendOrderInvoice invoice = new SendOrderInvoice();

            invoice.OrderID = Orderid;

            invoice.InvoiceNo = invoiceno;

            var details = CarTradingDBAccess.GetOrderDetails(Orderid);

            if (details != null)
            {
                invoice.CustomerName = details.CustomerName;
                invoice.CustomerEmail = details.CustomerEmail;
                invoice.CustomerContactNumber = details.CustomerContactNumber;
                invoice.CustomerAddress = details.CustomerAddress;
                invoice.DeliveryAddress = details.DeliveryAddress;

                invoice.ModelName = details.Model.ModelName;
                invoice.BasePrice = BasePrice;
                invoice.SeaPortCost = SeaPortCost;
                invoice.ShiftingCost = ShiftingCost;
                invoice.VAT = VAT;
                invoice.TotalCost = VAT + ShiftingCost + SeaPortCost + BasePrice;
                invoice.AmountinWord = NumberToWords((int)invoice.TotalCost);
                if (details.PortID == 0)
                {
                    invoice.PortName = details.OtherSeaport;
                    invoice.Country = "Other";
                }
                else
                {
                    invoice.PortName = details.SeaPort.SerPortName;
                    invoice.Country = CarTradingDBAccess.GetCountryNameBySeaPortId(details.PortID);
                }
            }

            var cardetails = CarTradingDBAccess.GetModelByID(Orderid);

            invoice.BrandName = cardetails.Brand.BrandName;
            invoice.YearOfRelease = cardetails.YearOfRelease;
            invoice.Price = cardetails.Price;
            invoice.BodyStyleName = cardetails.BodyType.BodyTypeName;
            invoice.EngineType = cardetails.EngineType;
            invoice.Displacement = cardetails.Displacement;
            invoice.Power = cardetails.Power;
            invoice.Torque = cardetails.Torque;
            invoice.Transmission = cardetails.Transmission;
            invoice.DriveTrain = cardetails.DriveTrain;
            invoice.NumberOfGears = cardetails.NumberOfGears;
            invoice.NumberofCylinders = cardetails.NumberofCylinders;
            invoice.Performance0To100Kmph = cardetails.Performance0To100Kmph;
            invoice.MaximumSpeed = cardetails.MaximumSpeed;
            invoice.FuelTankCapacity = cardetails.FuelTankCapacity;
            invoice.BodyColor = cardetails.BodyColor;
            invoice.Length = cardetails.Length;
            invoice.Width = cardetails.Width;
            invoice.Height = cardetails.Height;
            invoice.Wheelbase = cardetails.Wheelbase;
            invoice.GrossWeight = cardetails.GrossWeight;
            invoice.SeatingCapacity = cardetails.SeatingCapacity;
            invoice.WheelType = cardetails.WheelType;
            invoice.FrontTyreSize = cardetails.FrontTyreSize;
            invoice.RearTyreSize = cardetails.RearTyreSize;
            invoice.FrontBrakeType = cardetails.FrontBrakeType;
            invoice.RearBrakeType = cardetails.RearBrakeType;
            invoice.FrontSuspension = cardetails.FrontSuspension;
            invoice.RearSuspension = cardetails.RearSuspension;
            invoice.PowerSteering = cardetails.PowerSteering;
            invoice.SteeringType = cardetails.SteeringType;

            double height = 375;
            return new Rotativa.ViewAsPdf(invoice)
            {
                PageSize = Rotativa.Options.Size.A4,

                PageOrientation = Rotativa.Options.Orientation.Landscape,

                PageMargins = new Margins(12, 12, 12, 12),// it’s in millimeters

                PageHeight = height,
                PageWidth = height*.76,

               
                //CustomSwitches = "--print-media-type --header-center"
                //CustomSwitches = "–outline –print - media - type –footer - center " + "Confidential" +  "–footer - right[page] /[toPage]  –footer - left[date]"   

            };
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}