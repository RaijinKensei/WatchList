using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWatchlist.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToFavouriteMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "FavouriteMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FavouriteMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "FavouriteMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "FavouriteMovies");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FavouriteMovies");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "FavouriteMovies");
        }
    }
}
