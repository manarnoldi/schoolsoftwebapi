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
    public class StaffCategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StaffCategoriesController> _logger;

        public StaffCategoriesController(IUnitOfWork unitOfWork, ILogger<StaffCategoriesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/StaffCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffCategory>>> GetStaffCategories()
        {
            _logger.LogInformation("Staff categories retrieved successfully!");
            return Ok(await _unitOfWork.StaffCategories.FindAll());
        }

        // GET: api/StaffCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffCategory>> GetStaffCategory(int id)
        {
            var staffCategory = await _unitOfWork.StaffCategories.GetById(id);

            if (staffCategory == null)
            {
                _logger.LogError("Requested staff category not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested staff category found!");
            return staffCategory;
        }

        // PUT: api/StaffCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffCategory(int id, StaffCategory _staffCategory)
        {
            var staffCategory = await _unitOfWork.StaffCategories.GetById(id);
            if (staffCategory == null)
            {
                _logger.LogError("Staff category to be editted not found!");
                return NotFound("Staff category to be editted not found!");
            }

            if (id != _staffCategory.Id)
            {
                _logger.LogError("Staff category to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.StaffCategories.Update(_staffCategory);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Staff category editted successfully");
            return NoContent();
        }

        // POST: api/StaffCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffCategory>> PostStaffCategory(StaffCategory _staffCategory)
        {
            var staffCategory = await _unitOfWork.StaffCategories.Find(r => r.Name == _staffCategory.Name);
            if (staffCategory.Count() > 0)
            {
                _logger.LogError("Staff category already exists in the database.");
                return Conflict("Staff category already exists in the database.");
            }

            _unitOfWork.StaffCategories.Add(_staffCategory);
            await _unitOfWork.Complete();
            _logger.LogInformation("Staff category added successfully");
            return CreatedAtAction("GetStaffCategory", new { id = _staffCategory.Id }, _staffCategory);
        }

        // DELETE: api/StaffCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffCategory(int id)
        {
            var staffCategory = await _unitOfWork.StaffCategories.GetById(id);
            if (staffCategory == null)
            {
                _logger.LogError("Staff category to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.StaffCategories.Remove(staffCategory);
            await _unitOfWork.Complete();
            _logger.LogInformation("Staff category deleted successfully");
            return NoContent();
        }
    }
}
