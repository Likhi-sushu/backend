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
    public class ScheduleAppointmentsController : ControllerBase
    {
        private readonly HappyHealthDbContext _context;

        public ScheduleAppointmentsController(HappyHealthDbContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleAppointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleAppointment>>> GetScheduleAppointment()
        {
            return await _context.ScheduleAppointment.ToListAsync();
        }

        // GET: api/ScheduleAppointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleAppointment>> GetScheduleAppointment(int id)
        {
            var scheduleAppointment = await _context.ScheduleAppointment.FindAsync(id);

            if (scheduleAppointment == null)
            {
                return NotFound();
            }

            return scheduleAppointment;
        }

        // PUT: api/ScheduleAppointments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleAppointment(int id, ScheduleAppointment scheduleAppointment)
        {
            if (id != scheduleAppointment.user_id)
            {
                return BadRequest();
            }

            _context.Entry(scheduleAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleAppointmentExists(id))
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

        // POST: api/ScheduleAppointments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ScheduleAppointment>> PostScheduleAppointment(ScheduleAppointment scheduleAppointment)
        {
            _context.ScheduleAppointment.Add(scheduleAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleAppointment", new { id = scheduleAppointment.user_id }, scheduleAppointment);
        }

        // DELETE: api/ScheduleAppointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScheduleAppointment>> DeleteScheduleAppointment(int id)
        {
            var scheduleAppointment = await _context.ScheduleAppointment.FindAsync(id);
            if (scheduleAppointment == null)
            {
                return NotFound();
            }

            _context.ScheduleAppointment.Remove(scheduleAppointment);
            await _context.SaveChangesAsync();

            return scheduleAppointment;
        }

        private bool ScheduleAppointmentExists(int id)
        {
            return _context.ScheduleAppointment.Any(e => e.user_id == id);
        }
    }
}
