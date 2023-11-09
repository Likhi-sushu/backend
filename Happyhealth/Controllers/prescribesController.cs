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
    public class prescribesController : ControllerBase
    {
        private readonly HappyHealthDbContext _context;

        public prescribesController(HappyHealthDbContext context)
        {
            _context = context;
        }

        // GET: api/prescribes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<prescribe>>> Getprescribe()
        {
            return await _context.prescribe.ToListAsync();
        }

        // GET: api/prescribes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<prescribe>> Getprescribe(int id)
        {
            var prescribe = await _context.prescribe.FindAsync(id);

            if (prescribe == null)
            {
                return NotFound();
            }

            return prescribe;
        }

        // PUT: api/prescribes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putprescribe(int id, prescribe prescribe)
        {
            if (id != prescribe.Id)
            {
                return BadRequest();
            }

            _context.Entry(prescribe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prescribeExists(id))
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

        // POST: api/prescribes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<prescribe>> Postprescribe(prescribe prescribe)
        {
            _context.prescribe.Add(prescribe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getprescribe", new { id = prescribe.Id }, prescribe);
        }

        // DELETE: api/prescribes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteprescribe(int id)
        {
            var prescribe = await _context.prescribe.FindAsync(id);
            if (prescribe == null)
            {
                return NotFound();
            }

            _context.prescribe.Remove(prescribe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool prescribeExists(int id)
        {
            return _context.prescribe.Any(e => e.Id == id);
        }
    }
}
