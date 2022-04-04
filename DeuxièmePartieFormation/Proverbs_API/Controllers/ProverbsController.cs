using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proverbs_API;
using Proverbs_API.Models;

namespace Proverbs_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProverbsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProverbsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Proverbs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proverb>>> GetProverbs()
        {
            return await _context.Proverbs.ToListAsync();
        }

        // GET: api/Proverbs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proverb>> GetProverb(int id)
        {
            var proverb = await _context.Proverbs.FindAsync(id);

            if (proverb == null)
            {
                return NotFound();
            }

            return proverb;
        }

        // PUT: api/Proverbs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProverb(int id, Proverb proverb)
        {
            if (id != proverb.Id)
            {
                return BadRequest();
            }

            _context.Entry(proverb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProverbExists(id))
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

        // POST: api/Proverbs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proverb>> PostProverb(Proverb proverb)
        {
            _context.Proverbs.Add(proverb);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProverb", new { id = proverb.Id }, proverb);
        }

        // DELETE: api/Proverbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProverb(int id)
        {
            var proverb = await _context.Proverbs.FindAsync(id);
            if (proverb == null)
            {
                return NotFound();
            }

            _context.Proverbs.Remove(proverb);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProverbExists(int id)
        {
            return _context.Proverbs.Any(e => e.Id == id);
        }
    }
}
