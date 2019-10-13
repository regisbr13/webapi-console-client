using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Access.Models;
using Microsoft.EntityFrameworkCore;
using Webapi.Data;
using Webapi.Repository.Interfaces;

namespace Webapi.Repository
{
public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
	{
        private readonly Context _context;
		 
		public Repository(Context context)
		{
			_context = context;
		}
		
		public async Task<List<TEntity>> FindAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
		
        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
			
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
		
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
				var updatedEntity = await FindByIdAsync(entity.Id);
				if(updatedEntity == null) return null;
				_context.Entry(updatedEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
		
        public async Task RemoveAsync(int id)
        {
            try
            {
                var entity = await FindByIdAsync(id);
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

        }
		
		public async Task<bool> ExistsAsync(TEntity entity)
		{
			return await _context.Set<TEntity>().AnyAsync(x => x.Id == entity.Id);
        }
	}
}