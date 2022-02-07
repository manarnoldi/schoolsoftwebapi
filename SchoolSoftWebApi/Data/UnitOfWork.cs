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
