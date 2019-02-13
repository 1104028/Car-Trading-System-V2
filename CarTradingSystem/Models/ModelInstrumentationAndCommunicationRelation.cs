using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class ModelInstrumentationAndCommunicationRelation
    {
        [Key, ForeignKey("Model"), Column(Order = 0)]
        public int ModelID { get; set; }
        public virtual Model Model { get; set; }

        [Key, ForeignKey("InstrumentationAndCommunication"), Column(Order = 1)]
        public int InstrumentationAndCommunicationID { get; set; }
        public virtual InstrumentationAndCommunication InstrumentationAndCommunication { get; set; }
    }
}