using SchoolSoftWeb.Model.Settings;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Students
{
    public class StudentParent : Base
    {
        public int RelationShipId { get; set; }
        public RelationShip RelationShip { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
    }
}
