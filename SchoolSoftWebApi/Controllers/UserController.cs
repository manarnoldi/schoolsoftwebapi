using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            _logger.LogInformation("Getting users from UserController.");
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUser(string id)
        {
            _logger.LogInformation("Getting user from UserController.");
            return Ok(await _userService.GetUser(id));
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRoles()
        {
            _logger.LogInformation("Getting roles from UserController.");
            return Ok(await _userService.GetRoles());
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            if (result.ErrorOccured)
            {
                _logger.LogError("An error occured while registering user.");
                return BadRequest(result.ResponseMessage);
            }
            else
            {
                _logger.LogInformation("User registered successfully.");
                return Ok(result.ResponseMessage);
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            if(result.IsAuthenticated)
            {
                _logger.LogInformation("User "+ result.UserName +" signed in to the system successfully.");
                return Ok(result);
            } else
            {
                _logger.LogError("User " + result.UserName + " did not magae to sign in to the system.");
                return Forbid();
            }
            
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
        {
            var result = await _userService.AddRoleAsync(model);
            _logger.LogInformation("Role " + model.Role+ " added to the system successfully.");
            return Ok(result);
        }
    }
}
