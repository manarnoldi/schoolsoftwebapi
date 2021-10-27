using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class Subject : Base
    {
        [Required(ErrorMessage = "Enter the subject code")]
        [Display(Name = "Subject code")]
        [StringLength(255)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Enter the subject name")]
        [Display(Name = "Subject name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the subject abbreviation")]
        [Display(Name = "Subject abbreviation")]
        [StringLength(255)]
        public string Abbr { get; set; }

        public int SubjectGroupId { get; set; }
        public SubjectGroup SubjectGroup { get; set; }
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
        public int StaffDetailsId { get; set; }
        public StaffDetails StaffDetails { get; set; }

        public List<StudentSubject> StudentSubjects { get; set; }
        public List<StaffSubject> StaffSubjects { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
