using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWatchlist.Api.Models;

namespace MovieWatchlist.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public FavoritesController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteMovie>>> GetFavorites()
        {
            return await _context.FavoriteMovies.ToListAsync();
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "Funziona!" });
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteMovie>> AddFavorite([FromBody] FavoriteMovie movie)
        {
            try
            {
                _context.FavoriteMovies.Add(movie);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetFavorites), new { id = movie.ImdbID }, new
                {
                    message = $"Movie '{movie.ImdbID}' added to the list."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore interno: {ex.Message}");
            }
        }

        [HttpDelete("{imdbId}")]
        public async Task<IActionResult> DeleteFavorite(string imdbId)
        {
            var movie = await _context.FavoriteMovies.FirstOrDefaultAsync(f => f.ImdbID == imdbId);
            if (movie == null)
                return NotFound();

            _context.FavoriteMovies.Remove(movie);
            await _context.SaveChangesAsync();
            return Ok(new { message = $"Film ID:'{imdbId}' rimosso dai preferiti." });
        }
    }
}
