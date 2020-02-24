using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyClone3.Models;

namespace VidlyClone3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsAPIController : ControllerBase
    {
        private readonly VidlyClone3Context _context;

        public CatsAPIController(VidlyClone3Context context)
        {
            _context = context;
        }

        // GET: api/CatsAPI
        [HttpGet]
        public IEnumerable<Cats> GetCats()
        {
            return _context.Cats;
        }

        // GET: api/CatsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cats>> GetCats(int id)
        {
            var cats = await _context.Cats.FindAsync(id);

            if (cats == null)
            {
                return NotFound();
            }

            return cats;
        }

        // PUT: api/CatsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCats(int id, Cats cats)
        {
            if (id != cats.Id)
            {
                return BadRequest();
            }

            _context.Entry(cats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatsExists(id))
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

        // POST: api/CatsAPI
        [HttpPost]
        public async Task<ActionResult<Cats>> PostCats(Cats cats)
        {
            _context.Cats.Add(cats);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCats", new { id = cats.Id }, cats);
        }

        // DELETE: api/CatsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cats>> DeleteCats(int id)
        {
            var cats = await _context.Cats.FindAsync(id);
            if (cats == null)
            {
                return NotFound();
            }

            _context.Cats.Remove(cats);
            await _context.SaveChangesAsync();

            return cats;
        }

        private bool CatsExists(int id)
        {
            return _context.Cats.Any(e => e.Id == id);
        }
    }
}
