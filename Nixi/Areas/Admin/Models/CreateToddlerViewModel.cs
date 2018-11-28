using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class CreateToddlerViewModel
    {
        [Key]
        public int Id { get; set; }

        public Toddler Toddler { get; set; }

        public Person Person { get; set; }

        public CMFile CMFile { get; set; }

        public AgreedPeriod AgreedPeriod { get; set; }

    }
}