using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Webapi.Interfaces.Business;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Business
{
    public class ComputerBusiness : IBusiness<Computer>
    {
        private readonly IComputerRepository _computerRepository;

        public ComputerBusiness(IComputerRepository repository)
        {
            _computerRepository = repository;
        }
        public async Task<bool> ExistsAsync(Computer entity)
        {
            return await _computerRepository.ExistsAsync(entity);
        }

        public async Task<List<Computer>> FindAllAsync()
        {
            return await _computerRepository.FindAllAsync();
        }

        public async Task<Computer> FindByIdAsync(int id)
        {
            return await _computerRepository.FindByIdAsync(id);
        }

        public async Task<Computer> InsertAsync(Computer entity)
        {
            var computerBase = await _computerRepository.FindUserByName(entity.Name);
            if(computerBase != null) {
                return new Computer { Id = computerBase.Id};
            }
            return await _computerRepository.InsertAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            await _computerRepository.RemoveAsync(id);
        }

        public async Task<Computer> UpdateAsync(Computer entity)
        {
            return await _computerRepository.UpdateAsync(entity);
        }
    }
}