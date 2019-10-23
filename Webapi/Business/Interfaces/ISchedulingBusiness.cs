using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Data.VO;
using Webapi.Models;

namespace Webapi.Business.Interfaces 
{
    public interface ISchedulingBusiness 
    {
        Task<List<SchedulingVO>> FindAllAsync ();
        Task<List<SchedulingVO>> FindAllAsync (int computerId);
        Task<SchedulingVO> FindByIdAsync (int id);
        Task<Scheduling> InsertAsync (SchedulingVO entity);
        Task<Scheduling> UpdateAsync (SchedulingVO entity);
        Task RemoveAsync (int id);
    }
}