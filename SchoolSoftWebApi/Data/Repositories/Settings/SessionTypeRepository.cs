using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class SessionTypeRepository : GenericRepository<SessionType>, ISessionTypeRepository
    {
        public SessionTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
