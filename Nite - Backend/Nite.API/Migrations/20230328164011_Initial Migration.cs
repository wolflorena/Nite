using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TVShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Audience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seasons = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TVShows",
                columns: new[] { "Id", "Audience", "Description", "Genre", "Name", "Seasons", "Status", "Year" },
                values: new object[,]
                {
                    { 1, "18+", "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.", "Drama", "Game of Thrones", 8, "Ended", 2011 },
                    { 2, "18+", "Each season has its own self-contained storyline and characters and it has been posed that each season will introduce a new location as well as new characters and storylines.", "Horror", "American Horror Story", 10, "On going", 2011 },
                    { 3, "18+", "Dexter is a serial killer with a \"code\" which directs his compulsions to kill only the guilty. As a blood spatter analyst for the Miami police, he has access to crime scenes, picking up clues and checking DNA to confirm a target's guilt before he kills them.", "Mystery", "Dexter", 8, "Ended", 2006 },
                    { 4, "16+", "The series follows a dangerously charming, intensely obsessive young man who goes to extreme measures to insert himself into the lives of those he is transfixed by.", "Psychological thriller", "You", 4, "On going", 2018 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "deeagabor@gmail.com", true, "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", "deeagabor" },
                    { 2, "wolflorena@gmail.com", true, "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", "wolflorena" },
                    { 3, "testunu@gmail.com", false, "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", "test1" },
                    { 4, "testdoi@gmail.com", false, "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f", "test2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TVShows");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
