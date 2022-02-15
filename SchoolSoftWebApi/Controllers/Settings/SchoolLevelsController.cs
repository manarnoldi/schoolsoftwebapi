using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Controllers.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolLevelsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SchoolLevelsController> _logger;

        public SchoolLevelsController(IUnitOfWork unitOfWork, ILogger<SchoolLevelsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/SchoolLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolLevel>>> GetSchoolLevels()
        {
            _logger.LogInformation("School levels retrieved successfully!");
            return Ok(await _unitOfWork.SchoolLevels.FindAll());
        }

        // GET: api/SchoolLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolLevel>> GetSchoolLevel(int id)
        {
            var schoollevel = await _unitOfWork.SchoolLevels.GetById(id); ;

            if (schoollevel == null)
            {
                _logger.LogError("Requested school level not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested school level found!");
            return schoollevel;
        }

        // PUT: api/SchoolLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolLevel(int id, SchoolLevel _schoolLevel)
        {
            var schoolLevel = await _unitOfWork.SchoolLevels.GetById(id);
            if (schoolLevel == null)
            {
                _logger.LogError("School level to be editted not found!");
                return NotFound("School level to be editted not found!");
            }

            if (id != _schoolLevel.Id)
            {
                _logger.LogError("School level to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.SchoolLevels.Update(_schoolLevel);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("School level editted successfully");
            return NoContent();
        }

        // POST: api/SchoolLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolLevel>> PostSchoolLevel(SchoolLevel _schoollevel)
        {
            var schoollevel = await _unitOfWork.SchoolLevels.Find(r => r.Name == _schoollevel.Name);
            if (schoollevel.Count() > 0)
            {
                _logger.LogError("School level already exists in the database.");
                return Conflict("School level already exists in the database.");
            }

            _unitOfWork.SchoolLevels.Add(_schoollevel);
            await _unitOfWork.Complete();
            _logger.LogInformation("School level added successfully");
            return CreatedAtAction("GetSchoolLevel", new { id = _schoollevel.Id }, _schoollevel);
        }

        // DELETE: api/SchoolLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolLevel(int id)
        {
            var schoollevel = await _unitOfWork.SchoolLevels.GetById(id);
            if (schoollevel == null)
            {
                _logger.LogError("School level to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.SchoolLevels.Remove(schoollevel);
            await _unitOfWork.Complete();
            _logger.LogInformation("School level deleted successfully");
            return NoContent();
        }
    }
}
