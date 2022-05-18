using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class StaffCategoryRepository : GenericRepository<StaffCategory>, IStaffCategoryRepository
    {
        public StaffCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
