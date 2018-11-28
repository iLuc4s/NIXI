using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class Settings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        // STRINGS
        public String CompanyName { get; set; }
        public String Locations { get; set; }
        public String Classes { get; set; }
        
        // BOOLEANS
        public Boolean WeWorkWithHalfDays { get; set; }
        public Boolean PayWhenIllness { get; set; }
        public Boolean WeBuyDiapers { get; set; }
        public Boolean SecondChildDiscount { get; set; }
        public Boolean SiblingNoGuarantee { get; set; } //Sibling don't have to pay for guarantee
        public Boolean PriceToPaycheck { get; set; }

        // LETS TALK NUMBERS
        public Double DayPrice { get; set; }
        public Double HalfDayPrice { get; set; }
        public Double DiaperPrice { get; set; }
        public Double SecondChildDiscountPrice { get; set; }
        public Double PriceToPayCheckFactor { get; set; }
                
    }
}