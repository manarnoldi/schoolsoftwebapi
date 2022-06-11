using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Class;

namespace SchoolSoftWeb.Controllers.Class
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SessionsController> _logger;
        public SessionsController(IUnitOfWork unitOfWork, ILogger<SessionsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Sessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessions()
        {
            _logger.LogInformation("Sessions retrieved successfully!");
            return Ok(await _unitOfWork.Sessions.Find(includeProperties: "AcademicYear,SessionType,Curriculum"));
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(int id)
        {
            var session = await _unitOfWork.Sessions.GetById(id);
            if (session == null)
            {
                _logger.LogError("Requested session not found!");
                return NotFound();
            }
            _logger.LogInformation("Requested session not found!");
            return session;
        }

        // PUT: api/Sessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(int id, Session _session)
        {
            var session = await _unitOfWork.Sessions.GetById(id);
            if (session == null)
            {
                _logger.LogError("Session to be editted not found!");
                return NotFound("Session to be editted not found!");
            }

            if (id != _session.Id)
            {
                _logger.LogError("Session to be editted is not set up correctly!");
                return BadRequest();
            }

            _unitOfWork.Sessions.Update(_session);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogCritical("Database update concurrency exception encountered.");
                throw;
            }
            _logger.LogInformation("Session editted successfully");
            return NoContent();
        }

        // POST: api/Sessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Session>> PostSession(Session _session)
        {
            _unitOfWork.Sessions.Add(_session);
            await _unitOfWork.Complete();
            _logger.LogInformation("Session added successfully");
            return CreatedAtAction("GetSession", new { id = _session.Id }, _session);
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var session = await _unitOfWork.Sessions.GetById(id);
            if (session == null)
            {
                _logger.LogError("Session to be deleted not found in the database.");
                return NotFound();
            }

            _unitOfWork.Sessions.Remove(session);
            await _unitOfWork.Complete();
            _logger.LogInformation("Session deleted successfully");
            return NoContent();
        }
    }
}
