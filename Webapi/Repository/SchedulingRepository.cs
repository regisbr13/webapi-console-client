using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webapi.Data;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Repository 
{
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository 
    {
        private readonly Context _context;
        public SchedulingRepository (Context context) : base (context) 
        {
            _context = context;
        }

        public async Task<List<Scheduling>> FindAllAsync (int computerId) 
        {
            return await _context.Schedulings.Where (x => x.ComputerId == computerId && string.IsNullOrEmpty (x.Response)).ToListAsync ();
        }
    }
}