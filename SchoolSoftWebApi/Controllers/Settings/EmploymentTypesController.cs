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
    public class EmploymentTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmploymentTypesController> _logger;

        public EmploymentTypesController(IUnitOfWork unitOfWork, ILogger<EmploymentTypesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/EmploymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentType>>> GetEmploymentTypes()
        {
            _logger.LogInformation("Employment types retrieved successfully!");
            return Ok(await _unitOfWork.EmploymentTypes.FindAll());
        }

        // GET: api/EmploymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentType>> GetEmploymentType(int id)
        {
            var emptype = await _unitOfWork.EmploymentTypes.GetById(id);
            if (emptype == null)
            {
                _logger.LogError("Requested employment type not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested employment type  found!");
            return emptype;
        }

        // PUT: api/EmploymentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentType(int id, EmploymentType _employmentType)
        {
            var employmentType = await _unitOfWork.EmploymentTypes.GetById(id);
            if (employmentType == null)
            {
                _logger.LogError("Employment type to be editted not found!");
                return NotFound("Employment type to be editted not found!");
            }

            if (id != _employmentType.Id)
            {
                _logger.LogError("Employment type to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.EmploymentTypes.Update(_employmentType);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Employment type editted successfully");
            return NoContent();
        }

        // POST: api/EmploymentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmploymentType>> PostEmploymentType(EmploymentType _employmentType)
        {
            var employmentType = await _unitOfWork.EmploymentTypes.Find(r => r.Name == _employmentType.Name);
            if (employmentType.Count() > 0)
            {
                _logger.LogError("Employment type already exists in the database.");
                return Conflict("Employment type already exists in the database.");
            }

            _unitOfWork.EmploymentTypes.Add(_employmentType);
            await _unitOfWork.Complete();
            _logger.LogInformation("Employment type added successfully");
            return CreatedAtAction("GetEmploymentType", new { id = _employmentType.Id }, _employmentType);
        }

        // DELETE: api/EmploymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentType(int id)
        {
            var employmentType = await _unitOfWork.EmploymentTypes.GetById(id);
            if (employmentType == null)
            {
                _logger.LogError("Employment type to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.EmploymentTypes.Remove(employmentType);
            await _unitOfWork.Complete();
            _logger.LogInformation("Employment type deleted successfully");
            return NoContent();
        }
    }
}
