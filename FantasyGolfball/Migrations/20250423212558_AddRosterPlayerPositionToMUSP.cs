using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddRosterPlayerPositionToMUSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RosterPlayerPosition",
                table: "MatchupUserSavedPlayers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17ea9918-a758-4bbd-ad39-9491e77b1a57", "AQAAAAIAAYagAAAAEEp0Dz22WjeVb6s/PAJZwPvg9kkYzoEiqTaep0gq3pPBft/tfDXiwgvx9kKt9SlXLA==", "403c7224-ba62-45d8-b271-c01a11eea61f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RosterPlayerPosition",
                table: "MatchupUserSavedPlayers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73ff2965-7dc6-4bc2-bb86-4ebed6e29709", "AQAAAAIAAYagAAAAECDP8XSlWLSEash8h3SM0CSRespJ2X2FNyklnQZmog+c4etQemrUhfj/lo7UodpjJw==", "5527d4b2-f8ba-4ca4-938b-34cc7bd11387" });
        }
    }
}
