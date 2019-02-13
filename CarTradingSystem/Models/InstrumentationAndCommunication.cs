using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class InstrumentationAndCommunication
    {
        [Key]
        public int InstrumentationAndCommunicationID { get; set; }
        public string InstrumentationAndCommunicationDescription { get; set; }
    }
}