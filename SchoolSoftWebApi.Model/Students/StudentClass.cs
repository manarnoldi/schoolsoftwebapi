using SchoolSoftWeb.Model.Class;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Students
{
  public  class StudentClass: Base
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }

        public List<StudentAttendance> StudentAttendances { get; set; }
    }
}
