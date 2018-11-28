using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public Guid LocationId { get; set; }
        [Required]
        public String Name { get; set; }
        public int MaxToddlersEachDay { get; set; }

        public virtual ICollection<Person> Responsibles { get; set; }
        public virtual Location Location { get; set; }
    }
}