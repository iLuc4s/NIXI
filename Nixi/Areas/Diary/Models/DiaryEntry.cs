using Nixi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Diary.Models
{
    public class DiaryEntry
    {

        public Guid Id { get; set; }
        public Guid ToddlerId { get; set; }
        public DateTime Date { get; set; }
        public DiaryEntryStatus Status { get; set; }
        public String Comment { get; set; }
    }
}