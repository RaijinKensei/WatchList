using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWatchlist.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexOnImdbID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "FavoriteMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "FavoriteMovies");
        }
    }
}
