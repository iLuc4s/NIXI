using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public String ToddlerId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public Double TotalPrice { get; set; }
        public Double PayedPrice { get; set; } //if the invoice has nog been correctly payed, this is whats already payed
        public Boolean Payed { get; set; }
        public Boolean Active { get; set; }
        public DateTime CreationDate { get; set; }
        
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}