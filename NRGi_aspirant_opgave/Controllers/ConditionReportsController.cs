#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NRGi_aspirant_opgave.Data;
using NRGi_aspirant_opgave.Models;
using Serilog;

/*
 This controller contains logger functions
 */

namespace NRGi_aspirant_opgave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionReportsController : ControllerBase
    {
        private readonly ConditionReportsContext _context;
        readonly ILogger<ConditionReportsController> _logger;
        readonly IDiagnosticContext _diagnosticContext;

        public ConditionReportsController(ConditionReportsContext context, ILogger<ConditionReportsController> logger, IDiagnosticContext diagnosticContext)
        {
            _context = context;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _diagnosticContext = diagnosticContext ??
                throw new ArgumentNullException(nameof(diagnosticContext));
        }

        // GET: api/ConditionReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConditionReport>>> GetConditionReport()
        {
            _logger.LogInformation("Get all ConditionReports");

            return await _context.ConditionReport.ToListAsync();
        }

        // GET: api/ConditionReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionReport>> GetConditionReport(int id)
        {
            var conditionReport = await _context.ConditionReport.FindAsync(id);

            _logger.LogInformation($"Get ConditionReport with {conditionReport.Id}");

            if (conditionReport == null)
            {
                _logger.LogInformation("ConditionReport was not found!");
                return NotFound();
            }

            return conditionReport;
        }

        // PUT: api/ConditionReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConditionReport(int id, ConditionReport conditionReport)
        {
            _logger.LogInformation($"Put on ConditionReport with {id}");

            if (id != conditionReport.Id)
            {
                _logger.LogInformation($"ConditionReport with {id} was not found");
                return BadRequest();
            }

            _context.Entry(conditionReport).State = EntityState.Modified;

            try
            {
                _logger.LogInformation($"Save ConditionReport with {id}");
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionReportExists(id))
                {
                    _logger.LogInformation($"ConditionReport with {id} does not exists in db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Error in ConditionReport put call");
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
            _logger.LogInformation("Post ConditionReport");

            _context.ConditionReport.Add(conditionReport);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Save new ConditionReport with {conditionReport.Id}");

            //return CreatedAtAction("GetConditionReport", new { id = conditionReport.Id }, conditionReport);
            return CreatedAtAction(nameof(GetConditionReport), new { id = conditionReport.Id }, conditionReport);
        }

        // DELETE: api/ConditionReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConditionReport(int id)
        {
            _logger.LogInformation("Delete ConditionReport");

            var conditionReport = await _context.ConditionReport.FindAsync(id);
            if (conditionReport == null)
            {
                _logger.LogInformation($"ConditionReport with {id} was not found!");
                return NotFound();
            }

            _logger.LogInformation($"Deleted ConditionReport with {id}");
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
