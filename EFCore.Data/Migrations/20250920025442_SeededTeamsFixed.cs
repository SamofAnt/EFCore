using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeamsFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 9, 20, 2, 41, 50, 31, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 9, 20, 2, 41, 50, 31, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 9, 20, 2, 41, 50, 31, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 9, 20, 2, 41, 50, 31, DateTimeKind.Unspecified).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 9, 20, 2, 41, 50, 31, DateTimeKind.Unspecified).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 9, 20, 2, 41, 50, 31, DateTimeKind.Unspecified).AddTicks(8605));
        }
    }
}
