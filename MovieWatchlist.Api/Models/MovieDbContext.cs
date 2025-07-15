using Microsoft.EntityFrameworkCore;

namespace MovieWatchlist.Api.Models
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> option) : base(option) {}

        public DbSet<FavoriteMovie> FavoriteMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Vincolo unique su chiave ImdbID
            modelBuilder.Entity<FavoriteMovie>()
                .HasIndex(f => f.ImdbID)
                .IsUnique();
        }


    }
}
