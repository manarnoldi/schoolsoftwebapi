using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class ReligionRepository : GenericRepository<Religion>, IReligionRepository
    {
        public ReligionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
