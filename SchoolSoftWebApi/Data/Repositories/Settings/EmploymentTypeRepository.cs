using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class EmploymentTypeRepository : GenericRepository<EmploymentType>, IEmploymentTypeRepository
    {
        public EmploymentTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
