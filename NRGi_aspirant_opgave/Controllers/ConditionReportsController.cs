#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NRGi_aspirant_opgave.Data;
using NRGi_aspirant_opgave.Models;

namespace NRGi_aspirant_opgave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionReportsController : ControllerBase
    {
        private readonly NRGi_aspirant_opgaveContext _context;

        public ConditionReportsController(NRGi_aspirant_opgaveContext context)
        {
            _context = context;
        }

        // GET: api/ConditionReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConditionReport>>> GetConditionReport()
        {
            return await _context.ConditionReport.ToListAsync();
        }

        // GET: api/ConditionReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionReport>> GetConditionReport(int id)
        {
            var conditionReport = await _context.ConditionReport.FindAsync(id);

            if (conditionReport == null)
            {
                return NotFound();
            }

            return conditionReport;
        }

        // PUT: api/ConditionReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConditionReport(int id, ConditionReport conditionReport)
        {
            if (id != conditionReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(conditionReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ConditionReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConditionReport>> PostConditionReport(ConditionReport conditionReport)
        {
            //_context.ConditionReport.Add(new ConditionReport
            //{
            //    Id = 1,
            //    Name = "Test1",
            //    NumberOfBuildings = 1,
            //    NumberOfDamages = 1,
            //    DateOfModification = DateTime.Now,
            //});

            _context.ConditionReport.Add(conditionReport);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetConditionReport", new { id = conditionReport.Id }, conditionReport);
            return CreatedAtAction(nameof(GetConditionReport), new {id = conditionReport.Id}, conditionReport);
        }

        // DELETE: api/ConditionReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConditionReport(int id)
        {
            var conditionReport = await _context.ConditionReport.FindAsync(id);
            if (conditionReport == null)
            {
                return NotFound();
            }

            _context.ConditionReport.Remove(conditionReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConditionReportExists(int id)
        {
            return _context.ConditionReport.Any(e => e.Id == id);
        }
    }
}
