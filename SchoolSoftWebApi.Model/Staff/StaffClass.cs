using SchoolSoftWeb.Model.Class;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Staff
{
   public class StaffClass: Base
    {
        public int StaffDetailsId { get; set; }
        public StaffDetails StaffDetails { get; set; }
        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }        
    }
}
