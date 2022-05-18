using SchoolSoftWeb.Model.School;

namespace SchoolSoftWeb.Data.Repositories.School
{
    public class SchoolDetailsRepository : GenericRepository<SchoolDetails>, ISchoolDetailsRepository
    {
        public SchoolDetailsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
