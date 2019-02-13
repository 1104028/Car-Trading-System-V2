using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class BankAccountInformation
    {
        [Key]
        public int BankAccountID { get; set; }

        public string BankAccountName { get; set; }

        public string BankAccountNumber { get; set; }

        public string BankName { get; set; }

        public string Branch { get; set; }

        public string SWIFTCode { get; set; }

        public string ContactPerson { get; set; }

        public string ContactNumber { get; set; }
    }
}