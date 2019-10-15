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
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingsController : ControllerBase
    {
         private readonly SchedulingBusiness _business;

        public SchedulingsController(SchedulingBusiness business) {
            _business = business;
        }

        [HttpGet("{computerId}")]
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

        [HttpPost]
        [SwaggerResponse(201, Type = typeof(Scheduling))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]  
        public async Task<IActionResult> Post([FromBody] Scheduling obj)
        {
            if(obj == null)
                return BadRequest();
            return new ObjectResult(await _business.InsertAsync(obj));
        }

        [HttpPut("{id}")]
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