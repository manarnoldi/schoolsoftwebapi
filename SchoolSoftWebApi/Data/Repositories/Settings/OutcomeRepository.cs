using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class OutcomeRepository : GenericRepository<Outcome>, IOutcomeRepository
    {
        public OutcomeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
