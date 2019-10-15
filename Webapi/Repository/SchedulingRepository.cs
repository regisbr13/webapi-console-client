using Webapi.Data;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Repository
{
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
    {
        public SchedulingRepository(Context context) : base(context)
        {
        }
    }
}