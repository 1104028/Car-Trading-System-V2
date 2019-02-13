using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.ViewModel
{
    public class BrandAdd
    {
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
      
        [Display(Name = "Company Name")]
        public int CompanyID { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}