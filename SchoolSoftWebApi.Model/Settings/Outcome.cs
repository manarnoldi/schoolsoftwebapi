using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Settings
{
   public class Outcome: SettingsBase
    {
        public List<Discipline> Disciplines { get; set; }
    }
}
