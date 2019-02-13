using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class OrderDetails
    {
        public string ModelName { get; set; }
        public double Price { get; set; }
        public string PortName { get; set; }
        public string Country { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContactNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string DeliveryAddress { get; set; }

        public string OrderStatus { get; set; }
    }
}