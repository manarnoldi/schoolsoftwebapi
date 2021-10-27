using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Settings
{
   public class Occupation: SettingsBase
    {
        public List<Parent> Parents  { get; set; }
    }
}
