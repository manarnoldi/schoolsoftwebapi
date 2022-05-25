using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Academics;

namespace SchoolSoftWeb.Controllers.Academics
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CurriculaController> _logger;

        public CurriculaController(IUnitOfWork unitOfWork, ILogger<CurriculaController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Curricula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curriculum>>> GetCurricula()
        {
            _logger.LogInformation("Curricula retrieved successfully!");
            return Ok(await _unitOfWork.Curricula.FindAll());
        }

        // GET: api/Curricula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curriculum>> GetCurriculum(int id)
        {
            var curriculum = await _unitOfWork.Curricula.GetById(id);
            if (curriculum == null)
            {
                _logger.LogError("Requested curriculum not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested curriculum found!");
            return curriculum;
        }

        // PUT: api/Curricula/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurriculum(int id, Curriculum _curriculum)
        {
            var curriculum = await _unitOfWork.Curricula.GetById(id);
            if (curriculum == null)
            {
                _logger.LogError("Curriculum to be editted not found!");
                return NotFound("Curriculum to be editted not found!");
            }

            if (id != _curriculum.Id)
            {
                _logger.LogError("Curriculum to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Curricula.Update(_curriculum);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Curriculum editted successfully");
            return NoContent();
        }

        // POST: api/Curricula
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curriculum>> PostCurriculum(Curriculum _curriculum)
        {
            var curricula = await _unitOfWork.Designations.Find(r => r.Name == _curriculum.Name);
            if (curricula.Count() > 0)
            {
                _logger.LogError("Curriculum already exists in the database.");
                return Conflict("Curriculum already exists in the database.");
            }

            _unitOfWork.Curricula.Add(_curriculum);
            await _unitOfWork.Complete();
            _logger.LogInformation("Curriculum added successfully");
            return CreatedAtAction("GetCurriculum", new { id = _curriculum.Id }, _curriculum);
        }

        // DELETE: api/Curricula/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurriculum(int id)
        {
            var curriculum = await _unitOfWork.Curricula.GetById(id);
            if (curriculum == null)
            {
                _logger.LogError("Curriculum to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.Curricula.Remove(curriculum);
            await _unitOfWork.Complete();
            _logger.LogInformation("Curriculum deleted successfully");
            return NoContent();
        }
    }
}
