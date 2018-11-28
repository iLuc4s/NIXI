using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public String DaycareName { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual List<Class> Classes { get; set; }
    }
}