using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Webapi.Business;
using Webapi.Interfaces.Business;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SchedulingsController : Controller
    {
         private readonly SchedulingBusiness _business;

        public SchedulingsController(SchedulingBusiness business) {
            _business = business;
        }

        [HttpGet("schedulings/{computerId}")]
        [SwaggerResponse(200, Type = typeof(List<Scheduling>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [HttpGet]
        public async Task<ActionResult> Get(int computerId)
        {
            var obj = await _business.FindAllAsync(computerId);
            return Ok(obj);
        }

        [HttpGet("schedulings/getbyid/{id}")]
        [SwaggerResponse(200, Type = typeof(Scheduling))]
        [SwaggerResponse(204)]
        [SwaggerResponse(404)]
        [SwaggerResponse(401)]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var obj = await _business.FindByIdAsync(id);
            return Ok(obj);
        }

        [HttpPost("schedulings/")]
        [SwaggerResponse(201, Type = typeof(Scheduling))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]  
        public async Task<IActionResult> Post([FromBody] Scheduling obj)
        {
            if(obj == null)
                return BadRequest();
            return new ObjectResult(await _business.InsertAsync(obj));
        }

        [HttpPut("schedulings/{id}")]
        [SwaggerResponse(202, Type = typeof(Scheduling))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)] 
        public async Task<IActionResult> Put([FromBody] Scheduling obj)
        {
            if(obj == null) return BadRequest();
            var updatedobj = await _business.UpdateAsync(obj);
            if(updatedobj == null) return BadRequest("Scheduling doesn't exist in database");
            return new ObjectResult(await _business.UpdateAsync(obj));
        }
    }
}