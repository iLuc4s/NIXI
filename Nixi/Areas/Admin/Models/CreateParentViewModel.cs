using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class CreateParentViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid SubjectId { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //public DateTime DayOfBirth { get; set; }
        
        public Address Address { get; set; }
        //[EmailAddress]
        //public String EmailAddress { get; set; }
        //public String BillingAccount { get; set; }
        //public String HomePhone { get; set; }
        //public String CellPhone { get; set; }

        //public String WorkPhone { get; set; }
        //public String WorkPlaceName { get; set; }
        //public Address WorkAddress { get; set; }
        //public Double Paycheck { get; set; }

        //public String Comment { get; set; }
        //public String ImageId { get; set; }
        //public virtual Image Image { get; set; }

        //public Boolean Active { get; set; }
        //public DateTime CreationDate { get; set; }

        public virtual ICollection<Toddler> Children { get; set; }
    }
}