using SchoolSoftWeb.Model.Academics;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Staff
{
    public class StaffSubject : Base
    {
        public int StaffDetailsId { get; set; }
        public StaffDetails StaffDetails { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}
