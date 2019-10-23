using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webapi.Data;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Repository 
{
    public class ComputerRepository : Repository<Computer>, IComputerRepository 
    {
        private readonly Context _context;
        public ComputerRepository (Context context) : base (context) 
        {
            _context = context;
        }

        public async Task<List<Computer>> FindAllAsync (int userId) 
        {
            return await _context.Computers.Where (x => x.UserId == userId).ToListAsync ();
        }

        public async Task<Computer> FindUserByName (string name) 
        {
            return await _context.Computers.FirstOrDefaultAsync (x => x.Name == name);
        }
    }
}