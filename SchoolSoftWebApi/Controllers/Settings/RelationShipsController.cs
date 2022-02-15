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
    public class RelationShipsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RelationShipsController> _logger;
        public RelationShipsController(IUnitOfWork unitOfWork, ILogger<RelationShipsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/RelationShips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelationShip>>> GetRelationShips()
        {
            _logger.LogInformation("Relationships retrieved successfully!");
            return Ok(await _unitOfWork.Relationships.FindAll());
        }

        // GET: api/RelationShips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RelationShip>> GetRelationShip(int id)
        {
            var relationship = await _unitOfWork.Relationships.GetById(id); ;

            if (relationship == null)
            {
                _logger.LogError("Requested relationship not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested relationship found!");
            return relationship;
        }

        // PUT: api/RelationShips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelationShip(int id, RelationShip _relationship)
        {
            var relationship = await _unitOfWork.Relationships.GetById(id);
            if (relationship == null)
            {
                _logger.LogError("Relationships to be editted not found!");
                return NotFound("Relationships to be editted not found!");
            }

            if (id != _relationship.Id)
            {
                _logger.LogError("Relationship to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Relationships.Update(_relationship);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Relationship editted successfully");
            return NoContent();
        }

        // POST: api/RelationShips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RelationShip>> PostRelationShip(RelationShip _relationship)
        {
            var relationships = await _unitOfWork.Relationships.Find(r => r.Name == _relationship.Name);
            if (relationships.Count() > 0)
            {
                _logger.LogError("Relationship already exists in the database.");
                return Conflict("Relationship already exists in the database.");
            }

            _unitOfWork.Relationships.Add(_relationship);
            await _unitOfWork.Complete();
            _logger.LogInformation("Relationship added successfully");
            return CreatedAtAction("GetRelationShip", new { id = _relationship.Id }, _relationship);
        }

        // DELETE: api/RelationShips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelationShip(int id)
        {
            var relationship = await _unitOfWork.Relationships.GetById(id);
            if (relationship == null)
            {
                _logger.LogError("Relationship to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.Relationships.Remove(relationship);
            await _unitOfWork.Complete();
            _logger.LogInformation("Relationship deleted successfully");
            return NoContent();
        }
    }
}
