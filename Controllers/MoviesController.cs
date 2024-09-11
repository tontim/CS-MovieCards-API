using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;


namespace CS_MovieCards_API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DBContext db;
        private readonly IMapper mapper;

        public MoviesController(DBContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovie()
        {
            var movies = await db.Movie.ToListAsync();
            var dtos = mapper.Map<IEnumerable<MovieDto>>(movies);

            var movieDtos = await db.Movie.ProjectTo<MovieDto>(mapper.ConfigurationProvider).ToListAsync();

            return Ok(movieDtos);

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var movie = await db.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<MovieDto>(movie);

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
