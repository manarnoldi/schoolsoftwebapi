﻿using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Students
{
    [Table("StudentDisciplines")]
    public class StudentDiscipline : Discipline
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }        
    }
}
