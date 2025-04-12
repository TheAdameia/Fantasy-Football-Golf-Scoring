using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddIsLeagueFinishedAndMatchupWinner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Matchups",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLeagueFinished",
                table: "Leagues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25fd4f2e-2c57-41aa-95fd-b62db52cf5e3", "AQAAAAIAAYagAAAAEELYAlqzL0k48Dud6ahMriFfG86GU65P6Sjlqyy1TF2NQqQdnx/LhI5eP3Qy0i8Bpg==", "23fb6c22-48fb-42f9-8d10-8ba12ab884cd" });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 1,
                column: "IsLeagueFinished",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Matchups");

            migrationBuilder.DropColumn(
                name: "IsLeagueFinished",
                table: "Leagues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "214cc153-57cc-4ecf-8ec4-d293234d31e0", "AQAAAAIAAYagAAAAEE1yhFL848capWgbeM6kz49os286JD0FM7z5L0I3UFo/oHyusDAief7IdWjv/bgIPA==", "0a3a26fa-c6c3-4d45-b7ab-4889abf0998f" });
        }
    }
}
