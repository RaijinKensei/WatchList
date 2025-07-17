using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWatchlist.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToImdbID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMovies_ImdbID",
                table: "FavoriteMovies",
                column: "ImdbID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FavoriteMovies_ImdbID",
                table: "FavoriteMovies");
        }
    }
}
