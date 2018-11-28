using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class AddParentViewModel
    {
        public Guid SubjectId { get; set; }

        public List<Person> People { get; set; }
    }
}