using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Data.Repositories.Settings
{
    public class NationalityRepository: GenericRepository<Nationality>, INationalityRepository
    {
        public NationalityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
