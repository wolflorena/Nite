using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class Newproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Banner",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "TVShows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewSeason",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Streaming",
                table: "TVShows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Banner", "Likes", "Logo", "NewSeason", "Streaming" },
                values: new object[] { null, 1024, null, null, "Netflix" });

            migrationBuilder.UpdateData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Banner", "Likes", "Logo", "NewSeason", "Streaming" },
                values: new object[] { null, 2200, null, "11/12/2023", "HBO" });

            migrationBuilder.UpdateData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Banner", "Likes", "Logo", "NewSeason", "Streaming" },
                values: new object[] { null, 870, null, null, "Disney+" });

            migrationBuilder.UpdateData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Banner", "Likes", "Logo", "NewSeason", "Streaming" },
                values: new object[] { null, 2560, null, "12/10/2023", "Amazon Prime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "NewSeason",
                table: "TVShows");

            migrationBuilder.DropColumn(
                name: "Streaming",
                table: "TVShows");
        }
    }
}
