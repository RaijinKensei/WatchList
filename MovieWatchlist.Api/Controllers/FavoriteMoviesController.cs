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
        //chiamata per recuperare la lista di film aggiunti ai preferiti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteMovie>>> GetFavorites()
        {
            return await _context.FavoriteMovies.ToListAsync();
        }

        /**[HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "Funziona!" });
        }**/

        //chiamata per aggiungere ai preferiti il film ricercato
        [HttpPost]
        public async Task<ActionResult> AddFavorite([FromBody] FavoriteMovie movie)
        {
            // Controllo esplicito: il film è già tra i preferiti?
            var exists = await _context.FavoriteMovies.AnyAsync(f => f.ImdbID == movie.ImdbID);
            if (exists)
            {
                return Conflict(new { message = $"Film con ID '{movie.ImdbID}' è già tra i preferiti." });
            }

            try
            {
                _context.FavoriteMovies.Add(movie);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetFavorites), new { id = movie.ImdbID },
                    new { message = $"Film '{movie.ImdbID}' aggiunto." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errore interno: {ex.Message}");
            }
        }

        //chiamata per eliminare tramite imdbId il film dalla lista dei preferiti
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
