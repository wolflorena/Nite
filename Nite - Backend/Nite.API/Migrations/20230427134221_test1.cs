using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TVShows",
                keyColumn: "Id",
                keyValue: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TVShows",
                columns: new[] { "Id", "Audience", "Banner", "Description", "Genre", "Likes", "Logo", "Name", "NewSeason", "Poster", "Seasons", "Status", "Streaming", "Year" },
                values: new object[,]
                {
                    { 1, "18+", null, "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.", "Drama", 1024, null, "Game of Thrones", null, null, 8, "Ended", "Netflix", 2011 },
                    { 2, "18+", null, "Each season has its own self-contained storyline and characters and it has been posed that each season will introduce a new location as well as new characters and storylines.", "Horror", 2200, null, "American Horror Story", "11/12/2023", null, 10, "On going", "HBO", 2011 },
                    { 3, "18+", null, "Dexter is a serial killer with a \"code\" which directs his compulsions to kill only the guilty. As a blood spatter analyst for the Miami police, he has access to crime scenes, picking up clues and checking DNA to confirm a target's guilt before he kills them.", "Mystery", 870, null, "Dexter", null, null, 8, "Ended", "Disney+", 2006 },
                    { 4, "16+", null, "The series follows a dangerously charming, intensely obsessive young man who goes to extreme measures to insert himself into the lives of those he is transfixed by.", "Psychological thriller", 2560, null, "You", "12/10/2023", null, 4, "On going", "Amazon Prime", 2018 }
                });
        }
    }
}
