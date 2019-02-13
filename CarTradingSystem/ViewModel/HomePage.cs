using CarTradingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class HomePage
    {
        public List<BestSellingView> latestcarlist { get; set; }
        public List<BestSellingView> bestsellerlist { get; set; }
    }
}