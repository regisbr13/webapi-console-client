using System.Collections.Generic;
using System.Threading.Tasks;
using Webapi.Interfaces.Business;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Business
{
    public class UserBusiness : IBusiness<User>
    {
         private readonly IRepository<User> _repository;

        public UserBusiness(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<bool> ExistsAsync(User entity)
        {
            return await _repository.ExistsAsync(entity);
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<User> InsertAsync(User entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}