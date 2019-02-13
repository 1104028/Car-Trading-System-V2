using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class CarImageAdd
    {
        public int ModelID { get; set; }
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }
        
        public string Brand { get; set; }
      
    }
}