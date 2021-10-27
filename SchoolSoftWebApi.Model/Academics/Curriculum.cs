using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Class;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Academics
{
    public class Curriculum : Base
    {
        [Required(ErrorMessage = "Enter the curriculum code")]
        [Display(Name = "Curriculum code")]
        [StringLength(255)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Enter the curriculum name")]
        [Display(Name = "Curriculum name")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public List<Subject> Subjects { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Session> Sessions { get; set; }
        public List<SchoolClass> SchoolClasses { get; set; }        
    }
}
