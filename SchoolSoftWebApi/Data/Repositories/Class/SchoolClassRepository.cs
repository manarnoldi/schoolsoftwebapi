using SchoolSoftWeb.Model.Class;

namespace SchoolSoftWeb.Data.Repositories.Class
{
    public class SchoolClassRepository : GenericRepository<SchoolClass>, ISchoolClassRepository
    {
        public SchoolClassRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
