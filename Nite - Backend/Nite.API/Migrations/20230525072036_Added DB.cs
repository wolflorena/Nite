using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Add",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TVShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Add", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Add_TVShows_TVShowId",
                        column: x => x.TVShowId,
                        principalTable: "TVShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Add_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Add",
                columns: new[] { "Id", "TVShowId", "UserId" },
                values: new object[] { 1, 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Add_TVShowId",
                table: "Add",
                column: "TVShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Add_UserId",
                table: "Add",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Add");
        }
    }
}
