using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Models;

namespace Webapi.Repository.Interfaces 
{
    public interface IComputerRepository : IRepository<Computer> 
    {
        Task<Computer> FindUserByName (string name);
        Task<List<Computer>> FindAllAsync (int userId);
    }
}