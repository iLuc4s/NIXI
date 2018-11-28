using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class HeadCountMonthCalendarViewModel
    {
        public List<HeadcountByDay> HeadCountByDay { get; set; }
        public List<Class> AllClasses { get; set; }
        public Class TheClass { get;set; }


    }
}