using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movie.api.Data;
using movie.api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movie.api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {
            return await _context.Movies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(long id)
        {
            var record = await _context.Movies.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> Post(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = movie.ID }, movie);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.ID))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            var color = await _context.Movies.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(color);
            await _context.SaveChangesAsync();

            return color;
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }
    }
}