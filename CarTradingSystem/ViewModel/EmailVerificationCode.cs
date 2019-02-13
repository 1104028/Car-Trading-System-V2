using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class EmailVerificationCode
    {
       public string email { get; set; }
       public bool EmailSend { get; set; }
       public string Code { get; set; }
        
    }
}