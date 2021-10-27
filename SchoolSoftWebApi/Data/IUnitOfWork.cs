using SchoolSoftWeb.Data.Repositories.Academics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IAcademicYearRepository AcademicYears { get; }
        Task<int> Complete();
    }
}
