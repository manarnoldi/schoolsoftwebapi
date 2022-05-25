using SchoolSoftWeb.Model.Academics;

namespace SchoolSoftWeb.Data.Repositories.Academics
{
    public class CurriculumRepository: GenericRepository<Curriculum>, ICurriculumRepository
    {
        public CurriculumRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
