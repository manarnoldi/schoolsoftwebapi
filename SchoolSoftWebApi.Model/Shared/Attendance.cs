﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Shared
{
   public class Attendance: Base
    {
        [Display(Name = "Attendance date")]
        public DateTime Date { get; set; }

        public bool Present { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }
    }
}
