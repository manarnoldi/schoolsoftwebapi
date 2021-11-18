using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.School;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolSoftWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return Ok(await _unitOfWork.Events.FindAll());
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var schoolevent = await _unitOfWork.Events.GetById(id);
            if (schoolevent == null)
            {
                return NotFound();
            }
            return schoolevent;
        }

        // PUT: api/Event/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event _schoolevent)
        {
            var schoolevent = await _unitOfWork.Events.GetById(id);
            if (schoolevent == null)
            {
                return NotFound("School event to be editted not found!");
            }

            if (id != _schoolevent.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Events.Update(_schoolevent);
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event _schoolevent)
        {
            _unitOfWork.Events.Add(_schoolevent);
            await _unitOfWork.Complete();
            return CreatedAtAction("GetEvent", new { id = _schoolevent.Id }, _schoolevent);
        }

        // DELETE: api/Event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var schoolevent = await _unitOfWork.Events.GetById(id);
            if (schoolevent == null)
            {
                return NotFound();
            }

            _unitOfWork.Events.Remove(schoolevent);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
