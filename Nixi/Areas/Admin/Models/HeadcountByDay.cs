using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class HeadcountByDay
    {
        public DateTime Date { get; set; }

        public int AM_Count { get; set; }
        public int PM_Count { get; set; }
    }
}