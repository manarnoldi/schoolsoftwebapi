
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolSoftWeb.Data.Identity;
using SchoolSoftWeb.Model.Academics;
using SchoolSoftWeb.Model.Class;
using SchoolSoftWeb.Model.School;
using SchoolSoftWeb.Model.Settings;
using SchoolSoftWeb.Model.Shared;
using SchoolSoftWeb.Model.Staff;
using SchoolSoftWeb.Model.Students;
using SchoolSoftWeb.Services;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config,
             IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //Academics
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Curriculum> Curricula { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }

        //Class
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Session> Sessions { get; set; }

        //School
        public DbSet<Department> Departments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<LearningMode> LearningModes { get; set; }
        public DbSet<SchoolDetails> SchoolDetails { get; set; }

        //Settings
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<OccurenceType> OccurenceTypes { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<RelationShip> RelationShips { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<SchoolLevel> SchoolLevels { get; set; }
        public DbSet<SessionType> SessionTypes { get; set; }
        public DbSet<StaffCategory> StaffCategories { get; set; }

        //Staff
        public DbSet<StaffAttendance> StaffAttendances { get; set; }
        public DbSet<StaffClass> StaffClasses { get; set; }
        public DbSet<StaffDetails> StaffDetails { get; set; }
        public DbSet<StaffDiscipline> StaffDisciplines { get; set; }
        public DbSet<StaffSubject> StaffSubjects { get; set; }

        //Students
        public DbSet<FormerSchool> FormerSchools { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<StudentDiscipline> StudentDisciplines { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is Base && (e.State == EntityState.Added || e.State == EntityState.Modified));
            var user = _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var entityEntry in entries)
            {
                ((Base)entityEntry.Entity).Modified = DateTime.Now;
                ((Base)entityEntry.Entity).ModifiedBy = user;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Base)entityEntry.Entity).Created = DateTime.Now;
                    ((Base)entityEntry.Entity).CreatedBy = user;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
