using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSoftWeb.Data;
using SchoolSoftWeb.Model.Academics;

namespace SchoolSoftWeb.Academics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicYearsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcademicYearsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/AcademicYears
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicYear>>> GetAcademicYears()
        {
            //User.Claims.First
            return Ok(await _unitOfWork.AcademicYears.FindAll());
        }

        // GET: api/AcademicYears/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicYear>> GetAcademicYear(int id)
        {
            var academicyear = await _unitOfWork.AcademicYears.GetById(id);
            if (academicyear == null)
            {
                return NotFound();
            }

            return academicyear;
        }

        // PUT: api/AcademicYears/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicYear(int id, AcademicYear _academicYear)
        {
            var academicYear = await _unitOfWork.AcademicYears.GetById(id);
            if (academicYear == null)
            {
                return NotFound("Academic year to be editted not found!");
            }

            if (id != _academicYear.Id)
            {
                return BadRequest();
            }
            
            _unitOfWork.AcademicYears.Update(_academicYear);
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

        // POST: api/AcademicYears
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicYear>> PostAcademicYear(AcademicYear _academicYear)
        {
            _unitOfWork.AcademicYears.Add(_academicYear);
            await _unitOfWork.Complete();
            return CreatedAtAction("GetAcademicYear", new { id = _academicYear.Id }, _academicYear);
        }

        // DELETE: api/AcademicYears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicYear(int id)
        {
            var academicYear = await _unitOfWork.AcademicYears.GetById(id);
            if (academicYear == null)
            {
                return NotFound();
            }

            _unitOfWork.AcademicYears.Remove(academicYear);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
