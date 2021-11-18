using SchoolSoftWeb.Model.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Data.Repositories.School
{
    public class EventRepository: GenericRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
