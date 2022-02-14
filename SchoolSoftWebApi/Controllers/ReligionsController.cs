using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReligionsController> _logger;

        public ReligionsController(IUnitOfWork unitOfWork, ILogger<ReligionsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Religions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Religion>>> GetReligions()
        {
            _logger.LogInformation("Religions retrieved successfully!");
            return Ok(await _unitOfWork.Religions.FindAll());
        }

        // GET: api/Religions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Religion>> GetReligion(int id)
        {
            var religion = await _unitOfWork.Religions.GetById(id); ;

            if (religion == null)
            {
                _logger.LogError("Requested religion not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested religion found!");
            return religion;
        }

        // PUT: api/Religions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReligion(int id, Religion _religion)
        {
            var religion = await _unitOfWork.Religions.GetById(id);
            if (religion == null)
            {
                _logger.LogError("Religion to be editted not found!");
                return NotFound("Religion to be editted not found!");
            }

            if (id != _religion.Id)
            {
                _logger.LogError("Religion to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Religions.Update(_religion);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Religion editted successfully");
            return NoContent();
        }

        // POST: api/Religions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Religion>> PostReligion(Religion _religion)
        {
            var religions = await _unitOfWork.Religions.Find(r => r.Name == _religion.Name);
            if (religions.Count() > 0)
            {
                _logger.LogError("Religion already exists in the database.");
                return Conflict("Religion already exists in the database.");
            }

            _unitOfWork.Religions.Add(_religion);
            await _unitOfWork.Complete();
            _logger.LogInformation("Religion added successfully");
            return CreatedAtAction("GetReligion", new { id = _religion.Id }, _religion);
        }

        // DELETE: api/Religions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReligion(int id)
        {
            var religion = await _unitOfWork.Religions.GetById(id);
            if (religion == null)
            {
                _logger.LogError("Religion to be editted not found in the database.");
                return NotFound();
            }

            _unitOfWork.Religions.Remove(religion);
            await _unitOfWork.Complete();
            _logger.LogInformation("Religion deleted successfully");
            return NoContent();
        }
    }
}
