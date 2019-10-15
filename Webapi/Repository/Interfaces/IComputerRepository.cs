using System.Threading.Tasks;
using Webapi.Models;

namespace Webapi.Repository.Interfaces
{
    public interface IComputerRepository : IRepository<Computer>
    {
         Task<Computer> FindUserByName(string name);
    }
}