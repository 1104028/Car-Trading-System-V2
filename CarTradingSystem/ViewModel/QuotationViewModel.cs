using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.ViewModel
{
    public class QuotationViewModel
    {
        // Top side From Details Page
        public ThumbImageViewModel ThumbInfo { get; set; }
        //End Top

        public int ModelID { get; set; }

        public int CountryID { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }

        public string CountryName { get; set; }

        public int? SeaPortID { get; set; }
        public IEnumerable<SelectListItem> SeaPortList { get; set; }

        public string SeaPortName { get; set; }

        public int DeliveryID { get; set; }
        public IEnumerable<SelectListItem> DeliveryOptions { get; set; }

        public string DeliveryAddress { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}