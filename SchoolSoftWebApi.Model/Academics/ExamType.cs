using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Academics
{
    public class ExamType : SettingsBase
    {
        [Required(ErrorMessage = "Enter the exam type abbreviation")]
        [Display(Name = "Abbreviation")]
        [StringLength(255)]
        public string Abbreviation { get; set; }

        [Required(ErrorMessage = "Select if exam type is currently featured")]
        public bool Featured { get; set; }

        public List<Exam> Exams { get; set; }
    }
}
