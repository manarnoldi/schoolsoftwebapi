using SchoolSoftWeb.Model.School;
using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Settings
{
    public class SchoolLevel: SettingsBase
    {
        public List<SchoolDetails> SchoolDetails { get; set; }
        public List<FormerSchool> FormerSchools { get; set; }
    }
}
