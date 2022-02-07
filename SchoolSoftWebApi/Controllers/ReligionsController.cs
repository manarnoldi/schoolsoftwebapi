using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Settings;

namespace SchoolSoftWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReligionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Religions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Religion>>> GetReligions()
        {
            return Ok(await _unitOfWork.Religions.FindAll());
        }

        // GET: api/Religions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Religion>> GetReligion(int id)
        {
            var religion = await _unitOfWork.Religions.GetById(id); ;

            if (religion == null)
            {
                return NotFound();
            }

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
                return NotFound("Religion to be editted not found!");
            }

            if (id != _religion.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Religions.Update(_religion);
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

        // POST: api/Religions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Religion>> PostReligion(Religion _religion)
        {
            var religions = await _unitOfWork.Religions.Find(r => r.Name == _religion.Name);
            if (religions.Count() > 0)
            {
                return Conflict("Religion already exist in the database.");
            }

            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
            var userid = User.Claims.Where(x => x.Type == "id").FirstOrDefault()?.Value;

            _unitOfWork.Religions.Add(_religion);
            await _unitOfWork.Complete();
            return CreatedAtAction("GetReligion", new { id = _religion.Id }, _religion);
        }

        // DELETE: api/Religions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReligion(int id)
        {
            var religion = await _unitOfWork.Religions.GetById(id);
            if (religion == null)
            {
                return NotFound();
            }

            _unitOfWork.Religions.Remove(religion);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
