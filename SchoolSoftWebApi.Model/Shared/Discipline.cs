using SchoolSoftWeb.Model.Settings;
using SchoolSoftWeb.Model.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Shared
{
    [Table("Disciplines")]
    public abstract class Discipline : Base
    {
        [Required(ErrorMessage = "Enter occurence details")]
        [Display(Name = "Occurence details")]
        [StringLength(500)]
        public string OccurenceDetails { get; set; }


        [Required(ErrorMessage = "Enter occurence start date")]
        [Display(Name = "Occurence start date")]
        public DateTime OccurenceStartDate { get; set; }

        [Required(ErrorMessage = "Enter occurence end date")]
        [Display(Name = "Occurence end date")]
        public DateTime OccurenceEndDate { get; set; }
        
        [Display(Name = "Outcome details")]
        [StringLength(255)]
        public string OutcomeDetails { get; set; }

        public int OutcomeId { get; set; }
        public Outcome Outcome { get; set; }
        public int OccurenceTypeId { get; set; }
        public OccurenceType OccurenceType { get; set; }
    }
}
