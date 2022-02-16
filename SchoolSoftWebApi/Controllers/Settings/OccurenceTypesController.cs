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
    public class OccurenceTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OccurenceTypesController> _logger;

        public OccurenceTypesController(IUnitOfWork unitOfWork, ILogger<OccurenceTypesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/OccurenceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OccurenceType>>> GetOccurenceTypes()
        {
            _logger.LogInformation("Occurence types retrieved successfully!");
            return Ok(await _unitOfWork.OccurenceTypes.FindAll());
        }

        // GET: api/OccurenceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OccurenceType>> GetOccurenceType(int id)
        {
            var occurenceType = await _unitOfWork.OccurenceTypes.GetById(id);
            if (occurenceType == null)
            {
                _logger.LogError("Requested occurence Type not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested occurence type found!");
            return occurenceType;
        }

        // PUT: api/OccurenceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccurenceType(int id, OccurenceType _occurenceType)
        {
            var occurenceType = await _unitOfWork.OccurenceTypes.GetById(id);
            if (occurenceType == null)
            {
                _logger.LogError("Occurence type to be editted not found!");
                return NotFound("Occurence type to be editted not found!");
            }

            if (id != _occurenceType.Id)
            {
                _logger.LogError("Occurence type to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.OccurenceTypes.Update(_occurenceType);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Occurence type editted successfully");
            return NoContent();
        }

        // POST: api/OccurenceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OccurenceType>> PostOccurenceType(OccurenceType _occurenceType)
        {
            var occurenceType = await _unitOfWork.OccurenceTypes.Find(r => r.Name == _occurenceType.Name);
            if (occurenceType.Count() > 0)
            {
                _logger.LogError("Occurence type already exists in the database.");
                return Conflict("Occurence type already exists in the database.");
            }

            _unitOfWork.OccurenceTypes.Add(_occurenceType);
            await _unitOfWork.Complete();
            _logger.LogInformation("Occurence type added successfully");
            return CreatedAtAction("GetOccurenceType", new { id = _occurenceType.Id }, _occurenceType);
        }

        // DELETE: api/OccurenceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccurenceType(int id)
        {
            var occurenceType = await _unitOfWork.OccurenceTypes.GetById(id);
            if (occurenceType == null)
            {
                _logger.LogError("Occurence type to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.OccurenceTypes.Remove(occurenceType);
            await _unitOfWork.Complete();
            _logger.LogInformation("Occurence type deleted successfully");
            return NoContent();
        }
    }
}
