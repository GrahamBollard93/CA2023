using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonesApi.Data;
using PhonesApi.Model;

namespace PhonesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly PhonesDbContext _context;

        public PhonesController(PhonesDbContext context)
        {
            _context = context;
        }

        // GET: api/Phones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phones>>> GetPhone()
        {
          if (_context.Phone == null)
          {
              return NotFound();
          }
            return await _context.Phone.ToListAsync();
        }

        // GET: api/Phones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phones>> GetPhones(int id)
        {
          if (_context.Phone == null)
          {
              return NotFound();
          }
            var phones = await _context.Phone.FindAsync(id);

            if (phones == null)
            {
                return NotFound();
            }

            return phones;
        }

        // PUT: api/Phones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhones(int id, Phones phones)
        {
            if (id != phones.Id)
            {
                return BadRequest();
            }

            _context.Entry(phones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhonesExists(id))
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

        // POST: api/Phones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Phones>> PostPhones(Phones phones)
        {
          if (_context.Phone == null)
          {
              return Problem("Entity set 'PhonesDbContext.Phone'  is null.");
          }
            _context.Phone.Add(phones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhones", new { id = phones.Id }, phones);
        }

        // DELETE: api/Phones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhones(int id)
        {
            if (_context.Phone == null)
            {
                return NotFound();
            }
            var phones = await _context.Phone.FindAsync(id);
            if (phones == null)
            {
                return NotFound();
            }

            _context.Phone.Remove(phones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhonesExists(int id)
        {
            return (_context.Phone?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
