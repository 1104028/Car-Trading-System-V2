using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class BestSellingView
    {
        public int ModelID { get; set; }

        [Display(Name = "Model Name")]
        public string ModelName { get; set; }

        public double Price { get; set; }

        public string BodyStyle { get; set; }

        public string CardImage { get; set; }

    }
}