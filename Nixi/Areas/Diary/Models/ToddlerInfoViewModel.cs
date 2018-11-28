using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Diary.Models
{
    public class ToddlerInfoViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }

        public List<string> Parents { get; set; }
        public List<string> Siblings { get; set; }



    }
}