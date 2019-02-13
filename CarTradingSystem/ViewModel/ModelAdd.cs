using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarTradingSystem.ViewModel
{
    public class ModelAdd
    {
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }

        [Display(Name = "Company Name")]
        public int CompanyID { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }

        [Display(Name = "Brand Name")]
        public int BrandID { get; set; }
        public IEnumerable<SelectListItem> BrandList { get; set; }

        [Display(Name = "Year Of Release")]
        public int YearOfRelease { get; set; }
        public IEnumerable<SelectListItem> YearList { get; set; }

        public double Price { get; set; }

        [Display(Name = "Body Style")]
        public int BodyStyle { get; set; }
        public IEnumerable<SelectListItem> BodyStyleList { get; set; }

        [Display(Name = "Engine Type")]
        public string EngineType { get; set; }

        public string Displacement { get; set; }

        public string Power { get; set; }

        public string Torque { get; set; }

        public string Transmission { get; set; }

        [Display(Name = "Drive Train")]
        public string DriveTrain { get; set; }
        [Display(Name = "Number Of Gears")]
        public int NumberOfGears { get; set; }
        [Display(Name = "Number of Cylinders")]
        public int NumberofCylinders { get; set; }
        [Display(Name = "Performance 0 To 100 Kmph")]
        public string Performance0To100Kmph { get; set; }
        [Display(Name = "Maximum Speed")]
        public double MaximumSpeed { get; set; }
        [Display(Name = "Fuel Tank Capacity")]
        public double FuelTankCapacity { get; set; }
        [Display(Name = "Body Color")]
        public string BodyColor { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Wheelbase { get; set; }
        [Display(Name = "Gross Weight")]
        public string GrossWeight { get; set; }
        [Display(Name = "Seating Capacity")]
        public int SeatingCapacity { get; set; }
        [Display(Name = "Wheel Type")]
        public string WheelType { get; set; }
        [Display(Name = "Front Tyre Size")]
        public string FrontTyreSize { get; set; }
        [Display(Name = "Rear Tyre Size")]
        public string RearTyreSize { get; set; }

        [Display(Name = "Front Brake Type")]
        public string FrontBrakeType { get; set; }
        [Display(Name = "Rear Brake Type")]
        public string RearBrakeType { get; set; }
        [Display(Name = "Front Suspension")]
        public string FrontSuspension { get; set; }
        [Display(Name = "Rear Suspension")]
        public string RearSuspension { get; set; }
        [Display(Name = "Power Steering")]
        public string PowerSteering { get; set; }
        [Display(Name = "Steering Type")]
        public string SteeringType { get; set; }

        [Display(Name = "Not Available")]
        public bool NotAvailable { get; set; }

    }
}