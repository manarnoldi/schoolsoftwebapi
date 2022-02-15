using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class RelationshipRepository : GenericRepository<RelationShip>, IRelationshipRepository
    {
        public RelationshipRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
