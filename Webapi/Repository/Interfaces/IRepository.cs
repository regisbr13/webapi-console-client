using System.Collections.Generic;
using System.Threading.Tasks;
using Access.Models;

namespace Webapi.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(int? id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
		Task<bool> ExistsAsync(TEntity entity);
    }
}