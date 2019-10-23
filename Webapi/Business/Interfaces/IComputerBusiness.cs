using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Data.VO;
using Webapi.Models;

namespace Webapi.Business.Interfaces 
{
    public interface IComputerBusiness {
        Task<List<ComputerVO>> FindAllAsync ();
        Task<List<ComputerVO>> FindAllAsync (int userId);
        Task<ComputerVO> FindByIdAsync (int id);
        Task<Computer> InsertAsync (ComputerVO entity);
        Task RemoveAsync (int id);
    }
}