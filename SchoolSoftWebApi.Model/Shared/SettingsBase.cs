using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.School;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Shared
{
    public class SettingsBase : Base
    {
        [Required(ErrorMessage = "Enter the name")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
