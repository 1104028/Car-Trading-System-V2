using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarTradingSystem.ViewModel
{
    public class SendOrderInvoice
    {
        public string ModelName { get; set; }

        public string PortName { get; set; }
        public string Country { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContactNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string DeliveryAddress { get; set; }

        public string InvoiceNo { get; set; }

        public int OrderID { get; set; }

        public double BasePrice { get; set; }
        public double SeaPortCost { get; set; }
        public double ShiftingCost { get; set; }

        public double VAT { get; set; }

        public double TotalCost  { get; set; }
        public string AmountinWord  { get; set; }

        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        [Display(Name = "Year Of Release")]
        public int YearOfRelease { get; set; }

        public double Price { get; set; }

        [Display(Name = "Body Style")]
        public string BodyStyleName { get; set; }

        [Display(Name = "Engine Type")]
        public string EngineType { get; set; }
        public string Displacement { get; set; }
        public string Power { get; set; }
        public string Torque { get; set; }
        public string Transmission { get; set; }
        public string DriveTrain { get; set; }
        public int NumberOfGears { get; set; }
        public int NumberofCylinders { get; set; }
        public string Performance0To100Kmph { get; set; }
        public double MaximumSpeed { get; set; }
        public double FuelTankCapacity { get; set; }


        public string BodyColor { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Wheelbase { get; set; }
        public string GrossWeight { get; set; }
        public int SeatingCapacity { get; set; }

        public string WheelType { get; set; }
        public string FrontTyreSize { get; set; }
        public string RearTyreSize { get; set; }


        public string FrontBrakeType { get; set; }
        public string RearBrakeType { get; set; }

        public string FrontSuspension { get; set; }
        public string RearSuspension { get; set; }

        public string PowerSteering { get; set; }
        public string SteeringType { get; set; }
    }
}