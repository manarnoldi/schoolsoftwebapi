﻿using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Settings
{
    public class RelationShip : SettingsBase
    {
        public List<StudentParent> StudentParents { get; set; }

    }
}
