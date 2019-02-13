using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class BankPay
    {
        [Key]
        public int PayId { get; set; }

        [ForeignKey("orderInvoice")]
        public int OrderInvoiceID { get; set; }
        public virtual OrderInvoice orderInvoice { get; set; }

        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankIdentifierCode { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string BankReciptImage { get; set; }
        
    }
}