using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class OrderInvoice
    {
        [Key]
        public int OrderInvoiceID { get; set; }

        [Index("InvoiceNoIndex", IsUnique = true)]
        [MaxLength(15)]
        public string InvoiceNo { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }

        public double BasePrice { get; set; }
        public double SeaPortCost { get; set; }
        public double ShiftingCost { get; set; }

        public double VAT { get; set; }
     
    }
}