using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class BodyType
    {
        [Key]
        public int BodyTypeID { get; set; }
        public string BodyTypeName { get; set; }
    }
}