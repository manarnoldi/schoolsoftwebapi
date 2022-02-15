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
    public class OccupationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OccupationsController> _logger;

        public OccupationsController(IUnitOfWork unitOfWork, ILogger<OccupationsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Occupations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Occupation>>> GetOccupations()
        {
            _logger.LogInformation("Occupations retrieved successfully!");
            return Ok(await _unitOfWork.Occupations.FindAll());
        }

        // GET: api/Occupations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Occupation>> GetOccupation(int id)
        {
            var occupation = await _unitOfWork.Occupations.GetById(id); ;

            if (occupation == null)
            {
                _logger.LogError("Requested occupation not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested occupation found!");
            return occupation;
        }

        // PUT: api/Occupations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccupation(int id, Occupation _occupation)
        {
            var occupation = await _unitOfWork.Occupations.GetById(id);
            if (occupation == null)
            {
                _logger.LogError("Occupation to be editted not found!");
                return NotFound("Occupation to be editted not found!");
            }

            if (id != _occupation.Id)
            {
                _logger.LogError("Occupation to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Occupations.Update(_occupation);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Occupation editted successfully");
            return NoContent();
        }

        // POST: api/Occupations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Occupation>> PostOccupation(Occupation _occupation)
        {
            var occupations = await _unitOfWork.Occupations.Find(r => r.Name == _occupation.Name);
            if (occupations.Count() > 0)
            {
                _logger.LogError("Occupation already exists in the database.");
                return Conflict("Occupation already exists in the database.");
            }

            _unitOfWork.Occupations.Add(_occupation);
            await _unitOfWork.Complete();
            _logger.LogInformation("Occupation added successfully");
            return CreatedAtAction("GetOccupation", new { id = _occupation.Id }, _occupation);
        }

        // DELETE: api/Occupations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccupation(int id)
        {
            var occupation = await _unitOfWork.Occupations.GetById(id);
            if (occupation == null)
            {
                _logger.LogError("Occupation to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.Occupations.Remove(occupation);
            await _unitOfWork.Complete();
            _logger.LogInformation("Occupation deleted successfully");
            return NoContent();
        }
    }
}
