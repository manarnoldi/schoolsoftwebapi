using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.School;

namespace SchoolSoftWeb.Controllers.School
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolDetailsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SchoolDetailsController> _logger;

        public SchoolDetailsController(IUnitOfWork unitOfWork, ILogger<SchoolDetailsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/SchoolDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolDetails>>> GetSchoolDetails()
        {
            _logger.LogInformation("School details retrieved successfully!");
            return Ok(await _unitOfWork.SchoolDetails.FindAll());
        }

        // GET: api/SchoolDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDetails>> GetSchoolDetails(int id)
        {
            var schoolDetails = await _unitOfWork.SchoolDetails.GetById(id);
            if (schoolDetails == null)
            {
                _logger.LogError("Requested school details not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested school details not found!");
            return schoolDetails;
        }

        // PUT: api/SchoolDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolDetails(int id, SchoolDetails _schoolDetails)
        {
            var schoolDetails = await _unitOfWork.SchoolDetails.GetById(id);
            if (schoolDetails == null)
            {
                _logger.LogError("School details to be editted not found!");
                return NotFound("School details to be editted not found!");
            }

            if (id != _schoolDetails.Id)
            {
                _logger.LogError("School details to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.SchoolDetails.Update(_schoolDetails);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("School details edited successfully");
            return NoContent();
        }

        // POST: api/SchoolDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolDetails>> PostSchoolDetails(SchoolDetails _schoolDetails)
        {
            var schoolDetails = await _unitOfWork.SchoolDetails.Find(r => r.Name == _schoolDetails.Name);
            if (schoolDetails.Count() > 0)
            {
                _logger.LogError("School details already exists in the database.");
                return Conflict("School details already exists in the database.");
            }

            _unitOfWork.SchoolDetails.Add(_schoolDetails);
            await _unitOfWork.Complete();
            _logger.LogInformation("School details added successfully");
            return CreatedAtAction("GetSchoolDetails", new { id = _schoolDetails.Id }, _schoolDetails);
        }

        // DELETE: api/SchoolDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolDetails(int id)
        {
            var schoolDetails = await _unitOfWork.SchoolDetails.GetById(id);
            if (schoolDetails == null)
            {
                _logger.LogError("School details to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.SchoolDetails.Remove(schoolDetails);
            await _unitOfWork.Complete();
            _logger.LogInformation("School details deleted successfully");
            return NoContent();
        }
    }
}
