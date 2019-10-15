using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webapi.Data;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<User> FindUserByName(string username) 
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == username);
        }

        public async Task<User> InsertAsync(User user) 
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;;
        }
    }
}