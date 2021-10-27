using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.School;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Academics
{
    public class SubjectGroup : Base
    {
        [Required(ErrorMessage = "Enter the subject group")]
        [Display(Name = "Subject group name")]
        [StringLength(255)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
