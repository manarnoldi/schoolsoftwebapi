using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Controllers.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DesignationsController> _logger;

        public DesignationsController(IUnitOfWork unitOfWork, ILogger<DesignationsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Designations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Designation>>> GetDesignations()
        {
            _logger.LogInformation("Designations retrieved successfully!");
            return Ok(await _unitOfWork.Designations.FindAll());
        }

        // GET: api/Designations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Designation>> GetDesignation(int id)
        {
            var designation = await _unitOfWork.Designations.GetById(id);
            if (designation == null)
            {
                _logger.LogError("Requested designation not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested designation found!");
            return designation;
        }

        // PUT: api/Designations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignation(int id, Designation _designation)
        {
            var designation = await _unitOfWork.Designations.GetById(id);
            if (designation == null)
            {
                _logger.LogError("Designation to be editted not found!");
                return NotFound("Designation to be editted not found!");
            }

            if (id != _designation.Id)
            {
                _logger.LogError("Designation to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Designations.Update(_designation);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Designation editted successfully");
            return NoContent();
        }

        // POST: api/Designations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Designation>> PostDesignation(Designation _designation)
        {
            var desginations = await _unitOfWork.Designations.Find(r => r.Name == _designation.Name);
            if (desginations.Count() > 0)
            {
                _logger.LogError("Designation already exists in the database.");
                return Conflict("Desgination already exists in the database.");
            }

            _unitOfWork.Designations.Add(_designation);
            await _unitOfWork.Complete();
            _logger.LogInformation("Designation added successfully");
            return CreatedAtAction("GetDesignation", new { id = _designation.Id }, _designation);
        }

        // DELETE: api/Designations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var designation = await _unitOfWork.Designations.GetById(id);
            if (designation == null)
            {
                _logger.LogError("Designation to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.Designations.Remove(designation);
            await _unitOfWork.Complete();
            _logger.LogInformation("Designation deleted successfully");
            return NoContent();
        }
    }
}
