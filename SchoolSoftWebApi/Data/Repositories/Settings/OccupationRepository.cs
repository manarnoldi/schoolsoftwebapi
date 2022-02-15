using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class OccupationRepository : GenericRepository<Occupation>, IOccupationRepository
    {
        public OccupationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
