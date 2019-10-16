using System.Collections.Generic;
using System.Threading.Tasks;

namespace Webapi.Interfaces.Business
{
    public interface IBusiness<TEntity> where TEntity : class
    {
        Task<List<TEntity>> FindAllAsync();
        Task<List<TEntity>> FindAllAsync(int userId);
        Task<TEntity> FindByIdAsync(int id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
		Task<bool> ExistsAsync(TEntity entity);
    }
}