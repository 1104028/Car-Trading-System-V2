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
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var list = CarTradingDBAccess.GetAllOrders();

            return View(list);
        }

        public ActionResult Invoice(int id)
        {
            SendOrderInvoice invoice = new SendOrderInvoice();

            invoice.OrderID = id;

            Random rand = new Random((int)DateTime.Now.Ticks);

            int CharCode = rand.Next(Convert.ToInt32('a'), Convert.ToInt32('z'));
            char RandomChar = Convert.ToChar(CharCode);

            invoice.InvoiceNo = System.DateTime.Now.ToString("HH: mm:ss.fff");

            var details = CarTradingDBAccess.GetOrderDetails(id);

            if (details != null)
            {

                invoice.CustomerName = details.CustomerName;
                invoice.CustomerEmail = details.CustomerEmail;
                invoice.CustomerContactNumber = details.CustomerContactNumber;
                invoice.CustomerAddress = details.CustomerAddress;
                invoice.DeliveryAddress = details.DeliveryAddress;

                invoice.ModelName = details.Model.ModelName;
                invoice.BasePrice = details.Model.Price;

                if (details.PortID == 0)
                {
                    invoice.PortName = details.OtherSeaport;
                    invoice.Country = details.OtherCountryName;
                }
                else
                {
                    invoice.PortName = details.SeaPort.SerPortName;
                    invoice.Country = CarTradingDBAccess.GetCountryNameBySeaPortId(details.PortID);
                }

            }
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Invoice(SendOrderInvoice invoice)
        {
           if(ModelState.IsValid)
            {
                OrderInvoice oinvoice = new OrderInvoice();
                oinvoice.InvoiceNo = invoice.InvoiceNo;
                oinvoice.OrderID = invoice.OrderID;
                oinvoice.BasePrice = invoice.BasePrice;
                oinvoice.SeaPortCost = invoice.SeaPortCost;
                oinvoice.ShiftingCost = invoice.ShiftingCost;
                oinvoice.VAT = invoice.VAT;

                if(CarTradingDBAccess.AddOrderInvoice(oinvoice))
                {
                    SendOrderInvoice invoice1 = new SendOrderInvoice();
                    invoice1 = invoice;
                    return RedirectToAction("GeneratePDF","PDF", new { invoiceno = invoice.InvoiceNo, Orderid = invoice.OrderID, BasePrice = invoice.BasePrice, SeaPortCost = invoice.SeaPortCost, ShiftingCost = invoice.ShiftingCost, VAT = invoice.VAT });
                }
            }

            return View(invoice);
        }
    }
}