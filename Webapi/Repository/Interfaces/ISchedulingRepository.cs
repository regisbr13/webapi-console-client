using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Models;

namespace Webapi.Repository.Interfaces 
{
    public interface ISchedulingRepository : IRepository<Scheduling> 
    {
        Task<List<Scheduling>> FindAllAsync (int computerId);
    }
}