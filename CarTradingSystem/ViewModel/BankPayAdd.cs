using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.ViewModel
{
    public class BankPayAdd
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Invoice No required")]
        public string InvoiceNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bank Name required")]
        public string BankName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Branch Name required")]
        public string BranchName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Account Name required")]
        public string AccountName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Account Number required")]
        public string AccountNumber { get; set; }

        public string BankIdentifierCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount required")]
        public double Amount { get; set; }
    }
}