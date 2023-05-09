﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nite.API.Migrations
{
    /// <inheritdoc />
    public partial class TVShowSeasonsDBAdddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TVShowSeasons",
                columns: new[] { "Id", "DurationEpisode", "Name", "NumberOfEpisodes", "TVShowId" },
                values: new object[] { 2, 45, "Season 2", 12, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TVShowSeasons",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
