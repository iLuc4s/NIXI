using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class AgreedPeriod
    {
        // At the building of the contract this will be created where we have all the periods the child will be registered.
        // A child can have several periods (not overlapping)
        // To reserve a child in a class for a period, every day needs to have an Agreedday for each day in that period.

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Required]
        public Guid ToddlerId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public DayType Monday { get; set; }
        public DayType Tuesday { get; set; }
        public DayType Wednesday { get; set; }
        public DayType Thursday { get; set; }
        public DayType Friday { get; set; }
        public DayType Saturday { get; set; }
        public DayType Sunday { get; set; }
        public String Comment { get; set; }
        // Once this period is registered in AgreedDays, this period becomes "Active", to delete this period, all agreeddays in this period
        // need to be deleted as well.
        public Boolean Activated { get; set; }
        // This only tells that the period is active, inactive means the period isn't used.
        public Boolean Active { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }
    }
}