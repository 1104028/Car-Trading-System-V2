﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Address")]
        public string Address { get; set; }
        [Display(Name = "Company Country")]
        public string Country { get; set; } 
    }
}