using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.ViewModel
{
    public class BestSellingUpdate
    {
        public int BestSellingCarID { get; set; }

        public IEnumerable<SelectListItem> ModelList { get; set; }
        public int ModelId { get; set; }

        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public int? CompanyId { get; set; }

        public IEnumerable<SelectListItem> BrandList { get; set; }
        public int? BrandId { get; set; }
    }
}