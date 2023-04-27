using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class Poster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 1,
                column: "Poster",
                value: null);

            migrationBuilder.UpdateData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 2,
                column: "Poster",
                value: null);

            migrationBuilder.UpdateData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 3,
                column: "Poster",
                value: null);

            migrationBuilder.UpdateData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 4,
                column: "Poster",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "TVShows");
        }
    }
}
