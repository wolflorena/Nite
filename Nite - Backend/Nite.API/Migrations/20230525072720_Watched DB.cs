using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class WatchedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Add_TVShows_TVShowId",
                table: "Add");

            migrationBuilder.DropForeignKey(
                name: "FK_Add_Users_UserId",
                table: "Add");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Add",
                table: "Add");

            migrationBuilder.RenameTable(
                name: "Add",
                newName: "Added");

            migrationBuilder.RenameIndex(
                name: "IX_Add_UserId",
                table: "Added",
                newName: "IX_Added_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Add_TVShowId",
                table: "Added",
                newName: "IX_Added_TVShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Added",
                table: "Added",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Watched",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TVShowId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watched", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watched_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Watched_TVShowSeasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "TVShowSeasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Watched_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Watched_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Watched",
                columns: new[] { "Id", "EpisodeId", "SeasonId", "TVShowId", "UserId" },
                values: new object[] { 1, 1, 1, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Watched_EpisodeId",
                table: "Watched",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Watched_SeasonId",
                table: "Watched",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Watched_TVShowId",
                table: "Watched",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Watched_UserId",
                table: "Watched",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Added_TVShows_TVShowId",
                table: "Added",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Added_Users_UserId",
                table: "Added",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Added_TVShows_TVShowId",
                table: "Added");

            migrationBuilder.DropForeignKey(
                name: "FK_Added_Users_UserId",
                table: "Added");

            migrationBuilder.DropTable(
                name: "Watched");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Added",
                table: "Added");

            migrationBuilder.RenameTable(
                name: "Added",
                newName: "Add");

            migrationBuilder.RenameIndex(
                name: "IX_Added_UserId",
                table: "Add",
                newName: "IX_Add_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Added_TVShowId",
                table: "Add",
                newName: "IX_Add_TVShowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Add",
                table: "Add",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Add_TVShows_TVShowId",
                table: "Add",
                column: "TVShowId",
                principalTable: "TVShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Add_Users_UserId",
                table: "Add",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
