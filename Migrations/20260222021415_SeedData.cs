using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Game__Tournament_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "MaxPlayers", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ludwig är fotboll tränare", 32, "NBI skolan Nemos Lag" },
                    { 2, new DateTime(2026, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "E-sport turnering", 16, "CS2 Championship" },
                    { 3, new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schackturnering", 8, "Chess Masters" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Time", "Title", "TournamentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 6, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "Final Match", 1 },
                    { 2, new DateTime(2026, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Semi Final 1", 1 },
                    { 3, new DateTime(2026, 7, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), "Grand Final", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
