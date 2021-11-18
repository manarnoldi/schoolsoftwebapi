using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolSoftWeb.Data.Identity;
using SchoolSoftWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRoles()
        {
            return Ok(await _userService.GetRoles());
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            //if(result.ErrorOccured)
            //{
            //    return BadRequest(result.ResponseMessage);
            //} else
            //{
            return Ok(result.ResponseMessage);
            //}            
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            if(result.IsAuthenticated)
            {
                return Ok(result);
            } else
            {
                return Forbid();
            }
            
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
        {
            var result = await _userService.AddRoleAsync(model);
            return Ok(result);
        }
    }
}
