using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class InvoiceLine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public String InvoiceId { get; set; }
        public DayType? DayType { get; set; }
        public int NormalDays { get; set; }
        public int SecondChildDays { get; set; }
        public Double PriceDay { get; set; }
        public Double SecondChildPrice { get; set; }
        public Double SumPrice { get; set; }
    }
}