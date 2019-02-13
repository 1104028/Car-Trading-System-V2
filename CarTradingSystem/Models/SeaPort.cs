using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class SeaPort
    {
        [Key]
        public int SeaPortID { get; set; }
        public string SerPortCode { get; set; }
        public string SerPortName { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

    }
}