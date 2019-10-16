using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Webapi.Interfaces.Business;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
         private readonly IBusiness<Computer> _business;

        public ComputersController(IBusiness<Computer> business) {
            _business = business;
        }

        [HttpGet("{userId}")]
        [SwaggerResponse(200, Type = typeof(List<Computer>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]        
        public async Task<ActionResult> Get(int userId)
        {
            var obj = await _business.FindAllAsync(userId);
            if(obj == null)
                return Ok(new List<Computer>());
            return Ok(obj);
        }

        [HttpPost]
        [SwaggerResponse(201, Type = typeof(Computer))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]  
        public async Task<IActionResult> Post([FromBody] Computer obj)
        {
            if(obj == null) return BadRequest();
            obj.Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var computer = await _business.InsertAsync(obj);
            return Ok(computer.Id);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(202, Type = typeof(Computer))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]  
        public async Task<IActionResult> Put([FromBody] Computer obj)
        {
            if(obj == null) return BadRequest();
            var updatedobj = await _business.UpdateAsync(obj);
            if(updatedobj == null) return BadRequest("Computer doesn't exist in database");
            return new ObjectResult(await _business.UpdateAsync(obj));
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]          
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