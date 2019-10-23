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
    public class SchedulingBusiness : ISchedulingBusiness 
    {
        private readonly ISchedulingRepository _repository;
        private readonly SchedulingConverter _converter;

        public SchedulingBusiness (ISchedulingRepository repository, SchedulingConverter converter) {
            _repository = repository;
            _converter = converter;
        }

        public async Task<List<SchedulingVO>> FindAllAsync () {
            return _converter.ParseList (await _repository.FindAllAsync ());
        }

        public async Task<List<SchedulingVO>> FindAllAsync (int computerId) {
            var list = await _repository.FindAllAsync (computerId);
            return _converter.ParseList (list);
        }

        public async Task<SchedulingVO> FindByIdAsync (int id) {
            return _converter.Parse (await _repository.FindByIdAsync (id));
        }

        public async Task<Scheduling> InsertAsync (SchedulingVO entity) {
            return await _repository.InsertAsync (_converter.Parse (entity));
        }

        public async Task RemoveAsync (int id) {
            await _repository.RemoveAsync (id);
        }

        public async Task<Scheduling> UpdateAsync (SchedulingVO entity) {
            return await _repository.UpdateAsync (_converter.Parse (entity));
        }
    }
}