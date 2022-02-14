using SchoolSoftWeb.Data.Repositories.Academics;
using SchoolSoftWeb.Data.Repositories.School;
using SchoolSoftWeb.Data.Repositories.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data
{
    public interface IUnitOfWork : IDisposable
    {
        /** School **/
        IEventRepository Events { get; }
        /** Classes **/
        /** Academics **/
        IAcademicYearRepository AcademicYears { get; }
        /** Students **/
        /** Staff **/        
        /** Settings **/
        IGenderRepository Genders { get; }
        ISessionTypeRepository SessionTypes { get; }
        IReligionRepository Religions { get; }
        Task<int> Complete();
    }
}
