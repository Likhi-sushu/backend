using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Happyhealth;
using Happyhealth.Models;

namespace Happyhealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class patient_reportController : ControllerBase
    {
        private readonly HappyHealthDbContext _context;

        public patient_reportController(HappyHealthDbContext context)
        {
            _context = context;
        }

        // GET: api/patient_report
        [HttpGet]
        public async Task<ActionResult<IEnumerable<patient_report>>> Getpatient_report()
        {
            return await _context.patient_report.ToListAsync();
        }

        // GET: api/patient_report/5
        [HttpGet("{id}")]
        public async Task<ActionResult<patient_report>> Getpatient_report(int id)
        {
            var patient_report = await _context.patient_report.FindAsync(id);

            if (patient_report == null)
            {
                return NotFound();
            }

            return patient_report;
        }

        // PUT: api/patient_report/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpatient_report(int id, patient_report patient_report)
        {
            if (id != patient_report.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient_report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!patient_reportExists(id))
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

        // POST: api/patient_report
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<patient_report>> Postpatient_report(patient_report patient_report)
        {
            _context.patient_report.Add(patient_report);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpatient_report", new { id = patient_report.Id }, patient_report);
        }

        // DELETE: api/patient_report/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepatient_report(int id)
        {
            var patient_report = await _context.patient_report.FindAsync(id);
            if (patient_report == null)
            {
                return NotFound();
            }

            _context.patient_report.Remove(patient_report);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool patient_reportExists(int id)
        {
            return _context.patient_report.Any(e => e.Id == id);
        }
    }
}
