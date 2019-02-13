﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class LatestCar
    {
        [Key]
        public int LatestCarID { get; set; }
        [ForeignKey("Model")]
        public int ModelID { get; set; }
        public virtual Model Model { get; set; }
    }
}