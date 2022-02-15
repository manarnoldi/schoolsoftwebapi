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
    public class NationalitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NationalitiesController> _logger;

        public NationalitiesController(IUnitOfWork unitOfWork, ILogger<NationalitiesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Nationalities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nationality>>> GetNationalities()
        {
            _logger.LogInformation("Nationalities retrieved successfully!");
            return Ok(await _unitOfWork.Nationalities.FindAll());
        }

        // GET: api/Nationalities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nationality>> GetNationality(int id)
        {
            var nationality = await _unitOfWork.Nationalities.GetById(id);
            if (nationality == null)
            {
                _logger.LogError("Requested nationality not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested nationality found!");
            return nationality;
        }

        // PUT: api/Nationalities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNationality(int id, Nationality _nationality)
        {
            var nationality = await _unitOfWork.Nationalities.GetById(id);
            if (nationality == null)
            {
                _logger.LogError("Nationality to be editted not found!");
                return NotFound("Nationality to be editted not found!");
            }

            if (id != _nationality.Id)
            {
                _logger.LogError("Nationality to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Nationalities.Update(_nationality);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Nationality editted successfully");
            return NoContent();
        }

        // POST: api/Nationalities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nationality>> PostNationality(Nationality _nationality)
        {
            var nationalities = await _unitOfWork.Nationalities.Find(r => r.Name == _nationality.Name);
            if (nationalities.Count() > 0)
            {
                _logger.LogError("Nationality already exists in the database.");
                return Conflict("Nationality already exists in the database.");
            }

            _unitOfWork.Nationalities.Add(_nationality);
            await _unitOfWork.Complete();
            _logger.LogInformation("Nationality added successfully");
            return CreatedAtAction("GetNationality", new { id = _nationality.Id }, _nationality);
        }

        // DELETE: api/Nationalities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNationality(int id)
        {
            var nationality = await _unitOfWork.Nationalities.GetById(id);
            if (nationality == null)
            {
                _logger.LogError("Nationality to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.Nationalities.Remove(nationality);
            await _unitOfWork.Complete();
            _logger.LogInformation("Nationality deleted successfully");
            return NoContent();
        }
    }
}
