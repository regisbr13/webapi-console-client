using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Webapi.Business.Interfaces;
using Webapi.Models;
using Webapi.Data.VO;
using Tapioca.HATEOAS;
using System.Collections.Generic;

namespace Webapi.Controllers
{
    [Route ("api/schedulings/")]
    [ApiController]
    public class SchedulingsController : Controller 
    {
        private readonly ISchedulingBusiness _business;

        public SchedulingsController(ISchedulingBusiness business)
        {
            _business = business;
        }

        [HttpGet("{computerId}", Name = "GetAllSchedulings")]
        [SwaggerResponse(200, Type = typeof(List<SchedulingVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult> Get(int computerId)
        {
            var schedulings = await _business.FindAllAsync(computerId);
            return Ok(schedulings);
        }

        [HttpGet("getbyid/{id}", Name = "GetSchedulingById")]
        [SwaggerResponse(200, Type = typeof(SchedulingVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(404)]
        [SwaggerResponse(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<ActionResult> GetById(int id)
        {
            var obj = await _business.FindByIdAsync(id);
            return Ok(obj);
        }

        [HttpPost(Name = "NewScheduling")]
        [SwaggerResponse(201, Type = typeof(SchedulingVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]  
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Post([FromBody] SchedulingVO obj)
        {
            if(obj == null)
                return BadRequest();
            return new ObjectResult(await _business.InsertAsync(obj));
        }

        [HttpPut("{id}", Name = "UpScheduling")]
        [SwaggerResponse(202, Type = typeof(SchedulingVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)] 
        [TypeFilter(typeof(HyperMediaFilter))]
        public async Task<IActionResult> Put([FromBody] SchedulingVO obj)
        {
            if(obj == null) return BadRequest();
            var updatedobj = await _business.UpdateAsync(obj);
            if(updatedobj == null) return BadRequest("Scheduling doesn't exist in database");
            return new ObjectResult(await _business.UpdateAsync(obj));
        }

        [HttpDelete("{id}", Name = "DeleteScheduling")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)] 
        [TypeFilter(typeof(HyperMediaFilter))]         
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _business.FindByIdAsync(id);
            if(obj == null)
                return NotFound();
            await _business.RemoveAsync(id);
            return NoContent();
        }
    }
}