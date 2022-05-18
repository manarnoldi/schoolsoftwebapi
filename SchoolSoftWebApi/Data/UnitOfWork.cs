using SchoolSoftWeb.Data.Repositories.Academics;
using SchoolSoftWeb.Data.Repositories.School;
using SchoolSoftWeb.Data.Repositories.Settings;
using SchoolSoftWeb.Model.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            /** School **/
            Events = new EventRepository(_context);
            /** Classes **/
            /** Academics **/
            AcademicYears = new AcademicYearRepository(_context);
            /** Students **/
            /** Staff **/
            /** Settings **/
            SessionTypes = new SessionTypeRepository(_context);
            Religions = new ReligionRepository(_context);
            Genders = new GenderRepository(_context);
            Relationships = new RelationshipRepository(_context);
            Nationalities = new NationalityRepository(_context);
            SchoolLevels = new SchoolLevelRepository(_context);
            Occupations = new OccupationRepository(_context);
            Designations = new DesignationRepository(_context);
            EmploymentTypes = new EmploymentTypeRepository(_context);
            OccurenceTypes = new OccurenceTypeRepository(_context);
            Outcomes = new OutcomeRepository(_context);
            StaffCategories = new StaffCategoryRepository(_context);
            SchoolDetails = new SchoolDetailsRepository(_context);
        }
        /** School **/
        public IEventRepository Events { get; private set; }
        /** Classes **/
        /** Academics **/
        public IAcademicYearRepository AcademicYears { get; private set; }
        /** Students **/
        /** Staff **/
        /** Settings **/
        public ISessionTypeRepository SessionTypes { get; private set; }
        public IReligionRepository Religions { get; private set; }
        public IGenderRepository Genders { get; private set; }
        public IRelationshipRepository Relationships { get; private set; }
        public INationalityRepository Nationalities { get; private set; }
        public ISchoolLevelRepository SchoolLevels { get; private set; }
        public IOccupationRepository Occupations { get; private set; }
        public IDesignationRepository Designations { get; private set; }
        public IEmploymentTypeRepository EmploymentTypes { get; private set; }
        public IOccurenceTypeRepository OccurenceTypes { get; private set; }
        public IOutcomeRepository Outcomes { get; private set; }
        public IStaffCategoryRepository StaffCategories { get; private set; }
        public ISchoolDetailsRepository SchoolDetails { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
