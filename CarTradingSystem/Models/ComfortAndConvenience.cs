using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class ComfortAndConvenience
    {
        [Key]
        public int ComfortAndConvenienceID { get; set; }


        public string ComfortAndConvenienceDescription { get; set; }
    }
}