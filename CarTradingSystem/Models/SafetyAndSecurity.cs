using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class SafetyAndSecurity
    {
        [Key]
        public int SafetyAndSecurityID { get; set; }


        public string SafetyAndSecurityDescription { get; set; }
    }
}