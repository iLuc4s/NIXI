using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class AgreedDay
    {
        // the child has been registered in a class for a specific day and day type (full day AM PM)
        // When payed for this day, the payement status is payed)
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public Guid ToddlerId { get; set; }
        [Required]
        public Guid ClassId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public DayType? DayType { get; set; }
        public AgreedDaysStatus? AgreedDayStatus { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        // This ID is the period from which these AgreedDays were created.
        // If this is is empty, its an extra day that wasn't build in the agreed period.
        public Guid AgreedPeriodId { get; set; }
    }
}