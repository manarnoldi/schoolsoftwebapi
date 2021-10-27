﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Academics;
using SchoolSoftWeb.Model.Enums;
using SchoolSoftWeb.Model.School;
using SchoolSoftWeb.Model.Settings;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Class
{
    public class Session : Base
    {

        [Required(ErrorMessage = "Enter the session name.")]
        [Display(Name = "Session name")]
        [StringLength(255)]
        public string SessionName { get; set; }

        [Required(ErrorMessage = "Enter the session abbreviation.")]
        [Display(Name = "Session abbreviation")]
        [StringLength(255)]
        public string Abbreviation { get; set; }

        [Required(ErrorMessage = "Enter the session start date.")]
        [Display(Name = "Session start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Enter the session end date.")]
        [Display(Name = "Session end date")]
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }

        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
        public int SessionTypeId { get; set; }
        public SessionType SessionType { get; set; }

        public List<Exam> Exams { get; set; }
        public List<Event> Events { get; set; }
    }
}
