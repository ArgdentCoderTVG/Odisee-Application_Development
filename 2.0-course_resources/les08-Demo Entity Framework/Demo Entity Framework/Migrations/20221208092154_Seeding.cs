using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Inhoud", "PublicatieDatum", "Titel" },
                values: new object[,]
                {
                    { 1, "De inhoud van mijn bericht", new DateTime(2022, 12, 8, 10, 21, 53, 867, DateTimeKind.Local).AddTicks(2106), "Mijn eerste bericht" },
                    { 2, "De inhoud van het andere bericht", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mijn tweede bericht" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
