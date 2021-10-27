using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolSoftWeb.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Settings
{
   public class Religion: SettingsBase
    {
        public List<Person> People { get; set; }
    }
}
