using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class CardViewModel
    {
        public int CarID { get; set; }
        public string ModelName { get; set; }
        public string CarImage { get; set; }
        public string BodyType { get; set; }
        public double Price { get; set; }
        public string Message { get; set; }
    }
}