using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class SchoolLevelRepository: GenericRepository<SchoolLevel>, ISchoolLevelRepository
    {
        public SchoolLevelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
