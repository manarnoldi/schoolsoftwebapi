using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Class;
using SchoolSoftWeb.Model.Enums;
using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Staff;
using SchoolSoftWeb.Model.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Academics
{
    public class AcademicYear : Base
    {

        [Required(ErrorMessage = "Enter the academic year")]
        [Display(Name = "Academic year")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the academic year abbreviation")]
        [Display(Name = "Abbreviation")]
        [StringLength(255)]
        public string Abbreviation { get; set; }

        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public Status Status { get; set; }

        public List<SchoolClass> SchoolClasses { get; set; }
        public List<StaffSubject> StaffSubjects { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
