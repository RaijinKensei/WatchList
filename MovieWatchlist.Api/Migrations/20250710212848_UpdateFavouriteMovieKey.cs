using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWatchlist.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFavouriteMovieKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteMovies",
                columns: table => new
                {
                    ImdbID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteMovies", x => x.ImdbID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteMovies");
        }
    }
}
