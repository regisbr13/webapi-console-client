using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Interfaces.Business;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Business
{
    public class SchedulingBusiness : IBusiness<Scheduling>
    {
        private readonly IRepository<Scheduling> _repository;

        public SchedulingBusiness(IRepository<Scheduling> repository)
        {
            _repository = repository;
        }
        public async Task<bool> ExistsAsync(Scheduling entity)
        {
            return await _repository.ExistsAsync(entity);
        }

        public async Task<List<Scheduling>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<List<Scheduling>> FindAllNotExecutedAsync()
        {
            var list = await _repository.FindAllAsync();
            return list.Where(x => x.Response == null).ToList();
        }

        public async Task<Scheduling> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<Scheduling> InsertAsync(Scheduling entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<Scheduling> UpdateAsync(Scheduling entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}