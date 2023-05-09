using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeasonsDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TVShowSeasons",
                columns: new[] { "Id", "DurationEpisode", "Name", "NumberOfEpisodes", "TVShowId" },
                values: new object[,]
                {
                    { 1, 42, "Season 1", 10, 1 },
                    { 2, 45, "Season 2", 12, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TVShowSeasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TVShowSeasons",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
