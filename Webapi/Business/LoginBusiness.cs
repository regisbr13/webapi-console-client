using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Webapi.Business.Interfaces;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Business {
    public class LoginBusiness {
        private readonly IUserRepository _repository;

        public LoginBusiness (IUserRepository repository) {
            _repository = repository;
        }

        public async Task<User> InsertAsync (User entity) {
            return await _repository.InsertAsync (entity);
        }

        public async Task<bool> CheckLogin (User user) {
            var userBase = await FindUserByName (user.Login);
            if (userBase == null) return false;
            if (userBase.Login == user.Login && userBase.Password == user.Password)
                return true;
            return false;
        }

        public async Task<User> FindUserByName (string username) {
            return await _repository.FindUserByName (username);
        }
    }
}