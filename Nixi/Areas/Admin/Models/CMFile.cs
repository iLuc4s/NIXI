using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nixi.Areas.Admin.Models
{
    public class CMFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public virtual Toddler Toddler { get; set; }


        // Medical Info
        public String Doctor { get; set; }
        //public Address DoctorAddress { get; set; }
        //public String DoctorComment { get; set; }
        //public String Mutuality { get; set; }
        //public String Medication { get; set; }
        //public String MedicationComment { get; set; }
        //public String MedicationQTY { get; set; }
        //public String Allergies { get; set; }
        //public String MedicationForAllergies { get; set; }
        //public String ChildDeseases { get; set; }
        //public String ChildDeseasesWhen { get; set; }
        //public String SpecialCares { get; set; }
        //public String MedicalComment { get; set; }

        //// Nutrition Info
        //public String SpecialDiet { get; set; }
        //public String FoodAllergies { get; set; }
        //public String FoodNotAllowed { get; set; }
        //public String TypeOfBabyPowder { get; set; }
        //public String BottlesADay { get; set; }
        //public String NutritionComment { get; set; }

        //// Sleep Info
        //public String SleepingPosition { get; set; }
        //public String SleepingToy { get; set; }
        //public Boolean SleepingToyReturn { get; set; }
        //public String Pacifier { get; set; }
        //public String SleepComment { get; set; }

        //// Special Comment
        //public String SpecialComment { get; set; }

        //// DayCourse Info : What is the daily routine
        //public String DayCourse { get; set; }

        //public Boolean IsActive { get; set; }
        //public DateTime CreationDate { get; set; }
    }
}