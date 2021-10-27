using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Settings
{
 public   class Designation: SettingsBase
    {
        public List<StaffDetails> StaffDetails { get; set; }
    }
}
