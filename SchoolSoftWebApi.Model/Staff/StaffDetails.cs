using SchoolSoftWeb.Model.Academics;
using SchoolSoftWeb.Model.Class;
using SchoolSoftWeb.Model.School;
using SchoolSoftWeb.Model.Settings;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Staff
{
    [Table("Staffs")]
    public class StaffDetails : Person
    {
        [Display(Name = "School identity number")]
        [StringLength(255)]
        public string IdNumber { get; set; }

        public int StaffCategoryId { get; set; }
        public StaffCategory StaffCategory { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public int EmploymentTypeId { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public List<SchoolClass> SchoolClasses { get; set; }
        public List<StaffSubject> StaffSubjects { get; set; }
        public List<StaffAttendance> StaffAttendances { get; set; }
        public List<StaffDiscipline> StaffDisciplines { get; set; }
        public List<Department> Departments { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
