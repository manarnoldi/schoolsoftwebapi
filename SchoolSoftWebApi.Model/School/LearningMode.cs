using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.School
{
    public class LearningMode : Base
    {

        [Required(ErrorMessage = "Enter the learning mode.")]
        [Display(Name = "Learning mode")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public List<Student> Students { get; set; }
    }
}
