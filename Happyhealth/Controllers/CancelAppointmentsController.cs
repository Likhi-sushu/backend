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
    public class CancelAppointmentsController : ControllerBase
    {
        private readonly HappyHealthDbContext _context;

        public CancelAppointmentsController(HappyHealthDbContext context)
        {
            _context = context;
        }

        // GET: api/CancelAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CancelAppointment>>> GetCancelAppointment()
        {
            return await _context.CancelAppointment.ToListAsync();
        }

        // GET: api/CancelAppointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CancelAppointment>> GetCancelAppointment(int id)
        {
            var cancelAppointment = await _context.CancelAppointment.FindAsync(id);

            if (cancelAppointment == null)
            {
                return NotFound();
            }

            return cancelAppointment;
        }

        // PUT: api/CancelAppointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancelAppointment(int id, CancelAppointment cancelAppointment)
        {
            if (id != cancelAppointment.AppointmentId)
            {
                return BadRequest();
            }

            _context.Entry(cancelAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancelAppointmentExists(id))
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

        // POST: api/CancelAppointments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CancelAppointment>> PostCancelAppointment(CancelAppointment cancelAppointment)
        {
            _context.CancelAppointment.Add(cancelAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCancelAppointment", new { id = cancelAppointment.AppointmentId }, cancelAppointment);
        }

        // DELETE: api/CancelAppointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CancelAppointment>> DeleteCancelAppointment(int id)
        {
            var cancelAppointment = await _context.CancelAppointment.FindAsync(id);
            if (cancelAppointment == null)
            {
                return NotFound();
            }

            _context.CancelAppointment.Remove(cancelAppointment);
            await _context.SaveChangesAsync();

            return cancelAppointment;
        }

        private bool CancelAppointmentExists(int id)
        {
            return _context.CancelAppointment.Any(e => e.AppointmentId == id);
        }
    }
}
