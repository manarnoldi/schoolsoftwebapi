using SchoolSoftWeb.Model.Academics;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Students
{
    public class StudentSubject : Base
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int AcademicYearId {get; set; }
        public AcademicYear AcademicYear {get; set; }
    }
}
