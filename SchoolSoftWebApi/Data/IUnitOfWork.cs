using SchoolSoftWeb.Data.Repositories.Academics;
using SchoolSoftWeb.Data.Repositories.School;
using SchoolSoftWeb.Data.Repositories.Settings;
using System;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data
{
    public interface IUnitOfWork : IDisposable
    {
        /** School **/
        IEventRepository Events { get; }
        ISchoolDetailsRepository SchoolDetails { get; }
        /** Classes **/
        /** Academics **/
        IAcademicYearRepository AcademicYears { get; }
        /** Students **/
        /** Staff **/        
        /** Settings **/
        IGenderRepository Genders { get; }
        ISessionTypeRepository SessionTypes { get; }
        IReligionRepository Religions { get; }
        IRelationshipRepository Relationships { get; }
        INationalityRepository Nationalities { get; }
        ISchoolLevelRepository SchoolLevels { get; }
        IOccupationRepository Occupations { get; }
        IDesignationRepository Designations { get; }
        IEmploymentTypeRepository EmploymentTypes { get; }
        IOccurenceTypeRepository OccurenceTypes { get; }
        IOutcomeRepository Outcomes { get; }
        IStaffCategoryRepository StaffCategories { get; }
        Task<int> Complete();
    }
}
