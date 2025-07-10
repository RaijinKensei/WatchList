using Microsoft.EntityFrameworkCore;

namespace MovieWatchlist.Api.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> option) : base(option) {}

        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }

    }
}
