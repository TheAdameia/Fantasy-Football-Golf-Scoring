using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddedDraftStartTimeToLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DraftStartTime",
                table: "Leagues",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1015fd3-4853-4594-af1e-cab9f94441f3", "AQAAAAIAAYagAAAAEHTfMXRr29rgpX5tuhytT2Q+PiRo2oZJ4ES+aAUIuRug9iPhRmVT0l1Uz+mDmLWwqw==", "d0469efb-af2c-46ba-a1aa-d75ae1f402d5" });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 1,
                column: "DraftStartTime",
                value: new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DraftStartTime",
                table: "Leagues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8703d06b-436a-4944-ae6b-3c06b1651b69", "AQAAAAIAAYagAAAAEOY6FQr3zk2G57+IRk823FcPoF6/aMec//dpbJGHTxUmFrmk12Mew5cB1a6Sq2FzHA==", "a1463efb-bc20-4b5b-bcec-67d5e7824e9d" });
        }
    }
}
