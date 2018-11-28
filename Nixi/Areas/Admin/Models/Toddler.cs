using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class Toddler
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DayOfBirth { get; set; }
        public Gender? Gender { get; set; }

        //public String ImageId { get; set; }
        //public Image Image { get; set; }
        public Double GuaranteePrice { get; set; }
        
        //public Boolean Active { get; set; }
        //public DateTime CreationDate { get; set; }
        //public String Comment { get; set; }

        public virtual CMFile CMFile { get; set; }

        public virtual ICollection<Toddler> Siblings { get; set; }
        public virtual ICollection<Person> Parents { get; set;}
        public virtual ICollection<Person> Pickups { get; set; }

        public virtual ICollection<AgreedPeriod> AgreedPeriods { get; set; }
        public virtual ICollection<AgreedDay> AgreedDays { get; set; }

    }
}