using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Webapi.Business.Interfaces;
using Webapi.Models;
using Webapi.Data.VO;
using Tapioca.HATEOAS;

namespace Webapi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase {
         private readonly IComputerBusiness _business;

        public ComputersController(IComputerBusiness business) {
            _business = business;
        }

        [HttpGet("{userId}", Name = "GetAllComputer")]
        [SwaggerResponse(200, Type = typeof(List<ComputerVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]   
        [TypeFilter(typeof(HyperMediaFilter))]      
        public async Task<ActionResult> Get(int userId)
        {
            var obj = await _business.FindAllAsync(userId);
            if(obj == null)
                return Ok(new List<ComputerVO>());
            return Ok(obj);
        }

        [HttpPost(Name = "NewComputer")]
        [SwaggerResponse(201, Type = typeof(Computer))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]  
        [TypeFilter(typeof(HyperMediaFilter))] 
        public async Task<IActionResult> Post([FromBody] ComputerVO obj)
        {
            if(obj == null) return BadRequest();
            obj.Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var computer = await _business.InsertAsync(obj);
            return Ok(computer.Id);
        }

        [HttpDelete("{id}", Name = "DeleteComputer")]
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