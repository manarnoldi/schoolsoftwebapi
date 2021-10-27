using SchoolSoftWeb.Model.Academics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data.Repositories.Academics
{
    public class AcademicYearRepository: GenericRepository<AcademicYear>, IAcademicYearRepository
    {
        public AcademicYearRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
