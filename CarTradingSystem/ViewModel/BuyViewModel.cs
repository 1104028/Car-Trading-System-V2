using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class BuyViewModel
    {
        public List<CompanyList> CompanyList { get; set; }
        public List<BodyStyleList> BodyList { get; set; }
        public int CurrentYear { get; set; }
        public List<CardViewModel> SearchList { get; set; }
        public int? CompanyID { get; set; }
        public int? BodyType { get; set; }
        public int? YearMin { get; set; }
        public int? YearMax { get; set; }
        public int? PriceMin { get; set; }
        public int? PriceMax { get; set; }

    }
}