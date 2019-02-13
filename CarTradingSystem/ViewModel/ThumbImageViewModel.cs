using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class ThumbImageViewModel
    {
        public int CarID { get; set; }
        public string ModelName { get; set; }
        public string CarImage { get; set; }
        public double Price { get; set; }
        public string Country { get; set; }
        public int YearofRelease { get; set; }
    }
}