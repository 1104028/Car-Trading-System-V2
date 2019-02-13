using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.ViewModel
{
    public class SeaPortAdd
    {
        [Display(Name = "Sea Port Code")]
        public string SerPortCode { get; set; }

        [Display(Name = "Sea Port Name")]
        public string SerPortName { get; set; }

        [Display(Name = "Country Name")]
        public int CountryID { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
    }
}