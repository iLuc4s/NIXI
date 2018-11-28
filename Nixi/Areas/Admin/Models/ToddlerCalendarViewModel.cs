using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class ToddlerCalendarViewModel
    {
        public Toddler Toddler { get; set; }

        public DateTime Period { get; set; }

        public List<AgreedDay> AgreedDays { get; set; }

        public List<AgreedPeriod> AgreedPeriods { get; set; }
    }
}