using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Class;

namespace SchoolSoftWeb.Controllers.Class
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SchoolClassesController> _logger;

        public SchoolClassesController(IUnitOfWork unitOfWork, ILogger<SchoolClassesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/SchoolClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolClass>>> GetSchoolClasses()
        {
            _logger.LogInformation("School classes retrieved successfully!!");
            return Ok(await _unitOfWork.SchoolClasses.Find(includeProperties: "AcademicYear,Student,Curriculum"));
        }

        // GET: api/SchoolClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolClass>> GetSchoolClass(int id)
        {
            var schoolClass = await _unitOfWork.SchoolClasses.GetById(id);
            if (schoolClass == null)
            {
                _logger.LogError("Requested school class not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested school class not found!");
            return schoolClass;
        }

        // PUT: api/SchoolClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolClass(int id, SchoolClass _schoolClass)
        {
            var schoolClass = await _unitOfWork.SchoolClasses.GetById(id);
            if (schoolClass == null)
            {
                _logger.LogError("School class to be editted not found!");
                return NotFound("School class to be editted not found!");
            }

            if (id != _schoolClass.Id)
            {
                _logger.LogError("School class to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.SchoolClasses.Update(_schoolClass);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("School class edited successfully");
            return NoContent();
        }

        // POST: api/SchoolClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolClass>> PostSchoolClass(SchoolClass _schoolClass)
        {
            _unitOfWork.SchoolClasses.Add(_schoolClass);
            await _unitOfWork.Complete();
            _logger.LogInformation("School class added successfully");
            return CreatedAtAction("GetSession", new { id = _schoolClass.Id }, _schoolClass);
        }

        // DELETE: api/SchoolClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolClass(int id)
        {
            var schoolClass = await _unitOfWork.SchoolClasses.GetById(id);
            if (schoolClass == null)
            {
                _logger.LogError("School class to be deleted not found in the database.");
                return NotFound();
            }

            _unitOfWork.SchoolClasses.Remove(schoolClass);
            await _unitOfWork.Complete();
            _logger.LogInformation("School class deleted successfully");
            return NoContent();
        }
    }
}
