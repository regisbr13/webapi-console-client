using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Interfaces.Business;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Business
{
    public class ComputerBusiness : IBusiness<Computer>
    {
        private readonly IRepository<Computer> _repository;

        public ComputerBusiness(IRepository<Computer> repository)
        {
            _repository = repository;
        }
        public async Task<bool> ExistsAsync(Computer entity)
        {
            return await _repository.ExistsAsync(entity);
        }

        public async Task<List<Computer>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Computer> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<Computer> InsertAsync(Computer entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<Computer> UpdateAsync(Computer entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}