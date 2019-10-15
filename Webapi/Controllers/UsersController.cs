using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.Business;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
         private readonly LoginBusiness _business;

        public UsersController(LoginBusiness business) {
            _business = business;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(User user) 
        {
            if(await _business.FindUserByName(user.Login) == null) return BadRequest();
            var userInserted = await _business.InsertAsync(user);
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Login)};

            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            return Ok();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(User user)
        {
            if(await _business.CheckLogin(user))
            {
                var claims = new List<Claim>() {new Claim(ClaimTypes.NameIdentifier, user.Login)};
                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);					
                await HttpContext.SignInAsync(principal);
                var userId = (await _business.FindUserByName(user.Login)).Id;								
                return Ok(userId);
            }
            return Unauthorized();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();		
            return Ok();
        }
    }
}