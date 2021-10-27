using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Academics;
using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.School
{
    public class Department : Base
    {

        [Required(ErrorMessage = "Enter the department name.")]
        [StringLength(500)]
        [Display(Name = "Department name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the department code.")]
        [Display(Name = "Department code")]
        [StringLength(255)]
        public string Code { get; set; }

        public int StaffDetailsId { get; set; }
        public StaffDetails StaffDetails { get; set; }

        public List<SubjectGroup> SubjectGroups { get; set; }
    }
}
