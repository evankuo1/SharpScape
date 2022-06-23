using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharpScape.Api.Data;
using SharpScape.Api.Data.Models;

namespace SharpScape.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Commentors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commentor>>> GetCommentor()
        {
          if (_context.Commentor == null)
          {
              return NotFound();
          }
            return await _context.Commentor.ToListAsync();
        }

        // GET: api/Commentors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commentor>> GetCommentor(int id)
        {
          if (_context.Commentor == null)
          {
              return NotFound();
          }
            var commentor = await _context.Commentor.FindAsync(id);

            if (commentor == null)
            {
                return NotFound();
            }

            return commentor;
        }

        // PUT: api/Commentors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentor(int id, Commentor commentor)
        {
            if (id != commentor.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentorExists(id))
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

        // POST: api/Commentors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commentor>> PostCommentor(Commentor commentor)
        {
          if (_context.Commentor == null)
          {
              return Problem("Entity set 'AppDbContext.Commentor'  is null.");
          }
            _context.Commentor.Add(commentor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentor", new { id = commentor.Id }, commentor);
        }

        // DELETE: api/Commentors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentor(int id)
        {
            if (_context.Commentor == null)
            {
                return NotFound();
            }
            var commentor = await _context.Commentor.FindAsync(id);
            if (commentor == null)
            {
                return NotFound();
            }

            _context.Commentor.Remove(commentor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentorExists(int id)
        {
            return (_context.Commentor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
