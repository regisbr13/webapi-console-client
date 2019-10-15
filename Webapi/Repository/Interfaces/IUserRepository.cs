using System.Threading.Tasks;
using Webapi.Models;

namespace Webapi.Repository.Interfaces
{
    public interface IUserRepository
    {
         Task<User> FindUserByName(string username);
         Task<User> InsertAsync(User user);
    }
}