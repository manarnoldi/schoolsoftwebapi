using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class DesignationRepository : GenericRepository<Designation>, IDesignationRepository
    {
        public DesignationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
