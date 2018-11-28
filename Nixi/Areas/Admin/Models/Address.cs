using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public String Street { get; set; }
        public String Housenumber { get; set; }
        public String Bus { get; set; }
        public int Postalcode { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        
    }
}