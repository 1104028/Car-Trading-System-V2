using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [ForeignKey("Company")]
        [Display(Name = "Company Name")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

    }
}