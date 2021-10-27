﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Academics
{
    public class Grade : Base
    {
        [Required(ErrorMessage = "Enter the grade name")]
        [Display(Name = "Grade name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the abbreviation")]
        [Display(Name = "Grade abbreviation")]
        [StringLength(255)]
        public string Abbr { get; set; }

        [Required(ErrorMessage = "Enter the minimum score")]
        [Display(Name = "Minimum score")]
        public float MinScore { get; set; }

        [Required(ErrorMessage = "Enter the maximum score")]
        [Display(Name = "Maximum score")]
        public float MaxScore { get; set; }

        [Required(ErrorMessage = "Enter the grade points")]
        public float Points { get; set; }

        [Display(Name = "Remarks in Kiswahili")]
        public string RemarksSwa { get; set; }

        [Display(Name = "Remarks in English")]
        public string RemarksEng { get; set; }

        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
    }
}
