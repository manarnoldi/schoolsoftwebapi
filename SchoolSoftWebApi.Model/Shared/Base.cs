using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Model.Shared
{
    public abstract class Base
    {
        [BindNever]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Created { get; set; }

        [StringLength(255)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Modified { get; set; }

        [StringLength(255)]
        [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; }
    }
}
