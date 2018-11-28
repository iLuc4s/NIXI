using Nixi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Diary.Models
{
    public class ToddlerCard
    {
        public Guid ToddlerId { get; set; }
        public string Name { get; set; }
        public DiaryEntryStatus Status { get; set; }
    }
}