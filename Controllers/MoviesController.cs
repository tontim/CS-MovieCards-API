using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace CS_MovieCards_API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DBContext db;

        public MoviesController(DBContext context)
        {
            db = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovie()
        {
            var movies = db.Movie;
            var movieDtos = movies.Select(c => new MovieDto
            {
                Id = c.Id,
                Title = c.Title,
                Rating = c.Rating,
                ReleaseDate = c.ReleaseDate,
                Description = c.Description
            });

            return Ok(await movieDtos.ToListAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var movie = await db.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            var dto = new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
                Description = movie.Description

            };

            return Ok(dto);
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMovie(Guid id, Movie movie)
        //{
        //    if (id != movie.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(movie).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MovieExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        //{
        //    _context.Movie.Add(movie);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        //}

        // DELETE: api/Movies/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMovie(Guid id)
        //{
        //    var movie = await _context.Movie.FindAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Movie.Remove(movie);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool MovieExists(Guid id)
        //{
        //    return _context.Movie.Any(e => e.Id == id);
        //}
    }
}
