using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/SessionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionType>>> GetSessionTypes()
        {
            return Ok(await _unitOfWork.SessionTypes.FindAll());
        }

        // GET: api/SessionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionType>> GetSessionType(int id)
        {
            var sessiontypes = await _unitOfWork.SessionTypes.GetById(id);
            if (sessiontypes == null)
            {
                return NotFound();
            }
            return sessiontypes;
        }

        // PUT: api/SessionType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession(int id, SessionType _sessiontype)
        {
            var sessiontype = await _unitOfWork.SessionTypes.GetById(id);
            if (sessiontype == null)
            {
                return NotFound("Session type to be editted not found!");
            }

            if (id != _sessiontype.Id)
            {
                return BadRequest();
            }

            _unitOfWork.SessionTypes.Update(_sessiontype);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/SessionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SessionType>> PostSessionType(SessionType _sessiontype)
        {
            _unitOfWork.SessionTypes.Add(_sessiontype);
            await _unitOfWork.Complete();
            return CreatedAtAction("GetSessionType", new { id = _sessiontype.Id }, _sessiontype);
        }

        // DELETE: api/SessionType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessionType(int id)
        {
            var sessiontype = await _unitOfWork.SessionTypes.GetById(id);
            if (sessiontype == null)
            {
                return NotFound();
            }

            _unitOfWork.SessionTypes.Remove(sessiontype);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
