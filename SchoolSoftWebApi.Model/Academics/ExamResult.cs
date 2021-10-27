using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.School;
using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Academics
{
    public class ExamResult : Base
    {
        [Required(ErrorMessage = "Enter the examination score")]
        [Display(Name = "Examination score")]
        public float Score { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
