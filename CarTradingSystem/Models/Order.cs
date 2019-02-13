using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Model")]
        public int ModelID { get; set; }
        public virtual Model Model { get; set; }
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }
        public string CustomerContactNumber { get; set; }
        public string CustomerAddress { get; set; }

        [ForeignKey("SeaPort")]
        public int PortID { get; set; }
        public virtual SeaPort SeaPort { get; set; }

        public string OtherSeaport { get; set; }
        public string OtherCountryName { get; set; }

        public string DeliveryAddress { get; set; }

        public string OrderStatus { get; set; }
    }
}