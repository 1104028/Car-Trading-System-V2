using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarTradingSystem.Models
{
    public class CarImage
    {
        [Key]
        public int ImageID { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey("Model")]
        public int ModelID { get; set; }
        public virtual Model Model { get; set; }

        public bool ThumbImage { get; set; }
        public bool CardImage { get; set; }
    }
}