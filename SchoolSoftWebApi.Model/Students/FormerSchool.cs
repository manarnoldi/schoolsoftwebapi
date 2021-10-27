using SchoolSoftWeb.Model.Settings;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Students
{
    public class FormerSchool : Base
    {
        [Required(ErrorMessage = "Enter former school name")]
        [Display(Name = "School name")]
        [StringLength(255)]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Enter student former class details")]
        [Display(Name = "Class details")]
        [StringLength(255)]
        public string ClassDetails { get; set; }

        [StringLength(255)]
        [Display(Name = "Last exam marks and out of")]
        public string Score { get; set; }

        [StringLength(255)]
        [Display(Name = "Last position and out of")]
        public string Position { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SchoolLevelId { get; set; }
        public SchoolLevel SchoolLevel { get; set; }
    }
}
