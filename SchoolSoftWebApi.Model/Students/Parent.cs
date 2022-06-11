using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Settings;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Students
{
    [Table("Parents")]
    public class Parent : Person
    {
        [Display(Name = "Notify about student progress")]
        public bool Notifiable { get; set; }

        [Display(Name = "Pays school fees")]
        public bool Payer { get; set; }

        [Display(Name = "Picks up student")]
        public bool Pickup { get; set; }

        public int OccupationId { get; set; }
        public Occupation Occupation { get; set; }

        public List<StudentParent> Students { get; set; }
    }
}
