using SchoolSoftWeb.Model.Class;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolSoftWeb.Model.Settings
{
    public class SessionType : SettingsBase
    {
        public List<Session> Sessions { get; set; }
    }
}
