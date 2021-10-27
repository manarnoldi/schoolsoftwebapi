using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class SecuredController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSecuredData()
        {
            return Ok("This Secured Data get is available only for Authenticated Users.");
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> PostSecuredData()
        {
            return Ok("This Secured Data post is available only for Authenticated Users.");
        }
    }
}
