using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Students
{
  public  class StudentAttendance: Attendance
    {
        public int StudentClassId { get; set; }
        public StudentClass StudentClass { get; set; }        
    }
}
