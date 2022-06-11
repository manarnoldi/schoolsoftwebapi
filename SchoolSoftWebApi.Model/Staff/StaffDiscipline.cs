using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Staff
{
    [Table("StaffDisciplines")]
    public class StaffDiscipline : Discipline
    {
        public int StaffId { get; set; }
        public StaffDetails StaffDetails { get; set; }        
    }
}
