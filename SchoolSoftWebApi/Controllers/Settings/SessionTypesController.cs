using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SchoolSoftWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SessionTypesController> _logger;

        public SessionTypesController(IUnitOfWork unitOfWork, ILogger<SessionTypesController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/SessionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionType>>> GetSessionTypes()
        {
            _logger.LogInformation("Session types retrieved successfully!");
            return Ok(await _unitOfWork.SessionTypes.FindAll());
        }

        // GET: api/SessionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionType>> GetSessionType(int id)
        {
            var sessiontype = await _unitOfWork.SessionTypes.GetById(id);
            if (sessiontype == null)
            {
                _logger.LogError("Requested session type not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested session type found!");
            return sessiontype;
        }

        // PUT: api/SessionType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(int id, SessionType _sessiontype)
        {
            var sessiontype = await _unitOfWork.SessionTypes.GetById(id);
            if (sessiontype == null)
            {
                _logger.LogError("Session type to be editted not found!");
                return NotFound("Session type to be editted not found!");
            }

            if (id != _sessiontype.Id)
            {
                _logger.LogError("Session type to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.SessionTypes.Update(_sessiontype);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("session type editted successfully");
            return NoContent();
        }

        // POST: api/SessionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SessionType>> PostSessionType(SessionType _sessiontype)
        {
            var sessiontypes = await _unitOfWork.SessionTypes.Find(r => r.Name == _sessiontype.Name);
            if (sessiontypes.Count() > 0)
            {
                _logger.LogError("Session type already exists in the database.");
                return Conflict("Session type already exists in the database.");
            }

            _unitOfWork.SessionTypes.Add(_sessiontype);
            await _unitOfWork.Complete();
            _logger.LogInformation("Session type added successfully");
            return CreatedAtAction("GetSessionType", new { id = _sessiontype.Id }, _sessiontype);
        }

        // DELETE: api/SessionType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionType(int id)
        {
            var sessiontype = await _unitOfWork.SessionTypes.GetById(id);
            if (sessiontype == null)
            {
                _logger.LogError("Session type to be edited not found in the database.");
                return NotFound();
            }

            _unitOfWork.SessionTypes.Remove(sessiontype);
            await _unitOfWork.Complete();
            _logger.LogInformation("Session type deleted successfully");
            return NoContent();
        }
    }
}