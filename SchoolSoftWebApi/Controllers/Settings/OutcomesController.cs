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
    public class OutcomesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OutcomesController> _logger;

        public OutcomesController(IUnitOfWork unitOfWork, ILogger<OutcomesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Outcomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Outcome>>> GetOutcomes()
        {
            _logger.LogInformation("Outcomes retrieved successfully!");
            return Ok(await _unitOfWork.Outcomes.FindAll());
        }

        // GET: api/Outcomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Outcome>> GetOutcome(int id)
        {
            var outcome = await _unitOfWork.Outcomes.GetById(id); ;

            if (outcome == null)
            {
                _logger.LogError("Requested outcome not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested outcome found!");
            return outcome;
        }

        // PUT: api/Outcomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutcome(int id, Outcome _outcome)
        {
            var outcome = await _unitOfWork.Outcomes.GetById(id);
            if (outcome == null)
            {
                _logger.LogError("Outcome to be editted not found!");
                return NotFound("Outcome to be editted not found!");
            }

            if (id != _outcome.Id)
            {
                _logger.LogError("Outcome to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Outcomes.Update(_outcome);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Outcome editted successfully");
            return NoContent();
        }

        // POST: api/Outcomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Outcome>> PostOutcome(Outcome _outcome)
        {
            var outcomes = await _unitOfWork.Outcomes.Find(r => r.Name == _outcome.Name);
            if (outcomes.Count() > 0)
            {
                _logger.LogError("Outcome already exists in the database.");
                return Conflict("Outcome already exists in the database.");
            }

            _unitOfWork.Outcomes.Add(_outcome);
            await _unitOfWork.Complete();
            _logger.LogInformation("Outcome added successfully");
            return CreatedAtAction("GetOutcome", new { id = _outcome.Id }, _outcome);
        }

        // DELETE: api/Outcomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOutcome(int id)
        {
            var outcome = await _unitOfWork.Outcomes.GetById(id);
            if (outcome == null)
            {
                _logger.LogError("Outcome to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.Outcomes.Remove(outcome);
            await _unitOfWork.Complete();
            _logger.LogInformation("Outcome deleted successfully");
            return NoContent();
        }
    }
}
