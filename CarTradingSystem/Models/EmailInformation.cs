using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class EmailInformation
    {
        [Key]
        public int EmailID_PK { get; set; }
        [Display(Name = "SMTP Client Address")]
        public string SMTPclientAddr { get; set; }
        [Display(Name = "SMTP Client Port")]
        public int SMTPclientPort { get; set; }
        [Display(Name = "Email Address")]
        public string hostID { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string hostPass { get; set; }
    }
}