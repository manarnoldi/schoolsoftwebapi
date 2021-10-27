using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Academics;
using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Staff;
using SchoolSoftWeb.Model.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Class
{
    public class SchoolClass : Base
    {
        [Required(ErrorMessage = "Enter the class name")]
        [Display(Name = "Class name")]
        [StringLength(255)]
        public string ClassName { get; set; }

        [Required(ErrorMessage = "Enter the stream")]
        [StringLength(255)]
        public string Stream { get; set; }

        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public List<Exam> Exams { get; set; }
        public List<StaffClass> StaffClasses { get; set; }
        public List<StudentClass> StudentClasses { get; set; }
    }
}
