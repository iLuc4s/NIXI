using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class ClosingDay
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DayType? DayType { get; set; }
        public String LocationId { get; set; }
        public String ClassId { get; set; }
        public ClosingDayType? ClosingDayType { get; set; }
        public String Comment { get; set; }
    }
}