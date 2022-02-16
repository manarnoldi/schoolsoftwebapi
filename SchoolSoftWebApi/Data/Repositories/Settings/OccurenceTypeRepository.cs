using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class OccurenceTypeRepository : GenericRepository<OccurenceType>, IOccurenceTypeRepository
    {
        public OccurenceTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
