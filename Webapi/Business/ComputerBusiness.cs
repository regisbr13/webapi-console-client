using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi.Business.Interfaces;
using Webapi.Data.VO;
using Webapi.Data.VO.Converters;
using Webapi.Models;
using Webapi.Repository.Interfaces;

namespace Webapi.Business
{
    public class ComputerBusiness : IComputerBusiness 
    {
        private readonly IComputerRepository _computerRepository;
        private readonly ComputerConverter _converter;

        public ComputerBusiness (IComputerRepository repository, ComputerConverter converter) {
            _computerRepository = repository;
            _converter = converter;
        }

        public async Task<List<ComputerVO>> FindAllAsync () {
            return _converter.ParseList (await _computerRepository.FindAllAsync ());
        }

        public async Task<List<ComputerVO>> FindAllAsync (int userId) {
            var list = await _computerRepository.FindAllAsync (userId);
            if (list == null) return new List<ComputerVO> ();
            return (_converter.ParseList (list));
        }

        public async Task<ComputerVO> FindByIdAsync (int id) {
            return _converter.Parse (await _computerRepository.FindByIdAsync (id));
        }

        public async Task<Computer> InsertAsync (ComputerVO entity) {
            var computerBase = await _computerRepository.FindUserByName (entity.Name);
            if (computerBase != null) {
                return new Computer { Id = computerBase.Id };
            }
            return await _computerRepository.InsertAsync (_converter.Parse (entity));
        }

        public async Task RemoveAsync (int id) {
            await _computerRepository.RemoveAsync (id);
        }
    }
}