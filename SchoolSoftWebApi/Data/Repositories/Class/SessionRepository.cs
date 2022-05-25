using SchoolSoftWeb.Model.Class;

namespace SchoolSoftWeb.Data.Repositories.Class
{
    public class SessionRepository: GenericRepository<Session>, ISessionRepository
    {
        public SessionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
