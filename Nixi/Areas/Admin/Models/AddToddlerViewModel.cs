using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class AddToddlerViewModel
    {
        public Guid SubjectId { get; set; }

        public List<Toddler> Toddlers { get; set; }
    }
}