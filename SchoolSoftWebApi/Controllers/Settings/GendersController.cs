using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Controllers.Settings
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GendersController> _logger;

        public GendersController(IUnitOfWork unitOfWork, ILogger<GendersController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            _logger.LogInformation("Genders retrieved successfully!");
            return Ok(await _unitOfWork.Genders.FindAll());
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            var gender = await _unitOfWork.Genders.GetById(id);
            if (gender == null)
            {
                _logger.LogError("Requested gender not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested gender found!");
            return gender;
        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(int id, Gender _gender)
        {
            var gender = await _unitOfWork.Genders.GetById(id);
            if (gender == null)
            {
                _logger.LogError("Gender to be editted not found!");
                return NotFound("Gender to be editted not found!");
            }

            if (id != _gender.Id)
            {
                _logger.LogError("Gender to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Genders.Update(_gender);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Gender editted successfully");
            return NoContent();
        }

        // POST: api/Genders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender _gender)
        {
            var genders = await _unitOfWork.Genders.Find(r => r.Name == _gender.Name);
            if (genders.Count() > 0)
            {
                _logger.LogError("Gender already exists in the database.");
                return Conflict("Gender already exists in the database.");
            }

            _unitOfWork.Genders.Add(_gender);
            await _unitOfWork.Complete();
            _logger.LogInformation("Gender added successfully");
            return CreatedAtAction("GetGender", new { id = _gender.Id }, _gender);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var gender = await _unitOfWork.Genders.GetById(id);
            if (gender == null)
            {
                _logger.LogError("Gender to be editted not found in the database.");
                return NotFound();
            }

            _unitOfWork.Genders.Remove(gender);
            await _unitOfWork.Complete();
            _logger.LogInformation("Gender deleted successfully");
            return NoContent();
        }
    }
}
