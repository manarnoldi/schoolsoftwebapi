using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Settings
{
   public class Gender: SettingsBase
    {
        public List<Person> People { get; set; }
    }
}
