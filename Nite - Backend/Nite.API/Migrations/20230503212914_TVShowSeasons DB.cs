using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class TVShowSeasonsDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TVShowSeasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TVShowId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: false),
                    DurationEpisode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShowSeasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TVShowSeasons_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TVShowSeasons",
                columns: new[] { "Id", "DurationEpisode", "Name", "NumberOfEpisodes", "TVShowId" },
                values: new object[] { 1, 42, "Season 1", 10, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TVShowSeasons_TVShowId",
                table: "TVShowSeasons",
                column: "TVShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVShowSeasons");
        }
    }
}
