using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarTradingSystem.Models
{
    public class ModelSafetyAndSecurityRelation
    {

        [Key, ForeignKey("Model"), Column(Order = 0)]
        public int ModelID { get; set; }
        public virtual Model Model { get; set; }

        [Key, ForeignKey("SafetyAndSecurity"), Column(Order = 1)]
        public int SafetyAndSecurityID { get; set; }
        public virtual SafetyAndSecurity SafetyAndSecurity { get; set; }
    }
}