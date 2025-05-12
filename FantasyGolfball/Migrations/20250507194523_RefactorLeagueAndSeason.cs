using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class RefactorLeagueAndSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayerTeams_TeamId_TeamStartWeek_TeamEndWeek",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "Advancement",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "LastRecordedWeek",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "RealSeason",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SeasonStartDate",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "TeamEndWeek",
                table: "PlayerTeams");

            migrationBuilder.RenameColumn(
                name: "SeasonYear",
                table: "Scorings",
                newName: "SeasonId");

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Advancement",
                table: "Leagues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastRecordedWeek",
                table: "Leagues",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SeasonStartDate",
                table: "Leagues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73ead475-00a6-4d06-9155-dc662a8bae87", "AQAAAAIAAYagAAAAEGkzthEBYTXqJkxt7ufDfyY0gL5qqecmkUr1TP502pR93bCP2qfoE0iNHLX6sP/c6Q==", "48649f21-2e0b-4312-9d66-db07d5e43038" });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 1,
                columns: new[] { "Advancement", "LastRecordedWeek", "SeasonStartDate" },
                values: new object[] { 0, null, new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 6,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 7,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 8,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 9,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 10,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 11,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 12,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 13,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 14,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 15,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 16,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 17,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 18,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 19,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 20,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 21,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 22,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 23,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 24,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 25,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 26,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 27,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 28,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 29,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 30,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 31,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 32,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 33,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 34,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 35,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 36,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 37,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 38,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 39,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 40,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 41,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 42,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 43,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 44,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 45,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 46,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 47,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 48,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 49,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 50,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 51,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 52,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 53,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 54,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 55,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 56,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 57,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 58,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 59,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 60,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 61,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 62,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 63,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 64,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 65,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 66,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 67,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 68,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 69,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 70,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 71,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 72,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 73,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 74,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 75,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 76,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 77,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 78,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 79,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 80,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 81,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 82,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 83,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 84,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 85,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 86,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 87,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 88,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 89,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 90,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 91,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 92,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 93,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 94,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 95,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 96,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 97,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 98,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 99,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 100,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 101,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 102,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 103,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 104,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 105,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 106,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 107,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 108,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 109,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 110,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 111,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 112,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 113,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 114,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 115,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 116,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 117,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 118,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 119,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 120,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 121,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 122,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 123,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 124,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 125,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 126,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 127,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 128,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 129,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 130,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 131,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 132,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 133,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 134,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 135,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 136,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 137,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 138,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 139,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 140,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 141,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 142,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 143,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 144,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 145,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 146,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 147,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 148,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 149,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 150,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 151,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 152,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 153,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 154,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 155,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 156,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 157,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 158,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 159,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 160,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 1,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 2,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 3,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 4,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 5,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 6,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 7,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 8,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 9,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 10,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 11,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 12,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 13,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 14,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 15,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 16,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 17,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 18,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 19,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 20,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 21,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 22,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 23,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 24,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 25,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 26,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 27,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 28,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 29,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 30,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 31,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 32,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 33,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 34,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 35,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 36,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 37,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 38,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 39,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 40,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 41,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 42,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 43,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 44,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 45,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 46,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 47,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 48,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 49,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 50,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 51,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 52,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 53,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 54,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 55,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 56,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 57,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 58,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 59,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 60,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 61,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 62,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 63,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 64,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 65,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 66,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 67,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 68,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 69,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 70,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 71,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 72,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 73,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 74,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 75,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 76,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 77,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 78,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 79,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 80,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 81,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 82,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 83,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 84,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 85,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 86,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 87,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 88,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 89,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 90,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 91,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 92,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 93,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 94,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 95,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 96,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 97,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 98,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 99,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 100,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 101,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 102,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 103,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 104,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 105,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 106,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 107,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 108,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 109,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 110,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 111,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 112,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 113,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 114,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 115,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 116,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 117,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 118,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 119,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 120,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 121,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 122,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 123,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 124,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 125,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 126,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 127,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 128,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 129,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 130,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 131,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 132,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 133,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 134,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 135,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 136,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 137,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 138,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 139,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 140,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 141,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 142,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 143,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 144,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 145,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 146,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 147,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 148,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 149,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 150,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 151,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 152,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 153,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 154,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 155,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 156,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 157,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 158,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 159,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 160,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 161,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 162,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 163,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 164,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 165,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 166,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 167,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 168,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 169,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 170,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 171,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 172,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 173,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 174,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 175,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 176,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 177,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 178,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 179,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 180,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 181,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 182,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 183,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 184,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 185,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 186,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 187,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 188,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 189,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 190,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 191,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 192,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 193,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 194,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 195,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 196,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 197,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 198,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 199,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 200,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 201,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 202,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 203,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 204,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 205,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 206,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 207,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 208,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 209,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 210,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 211,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 212,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 213,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 214,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 215,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 216,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 217,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 218,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 219,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 220,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 221,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 222,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 223,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 224,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 225,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 226,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 227,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 228,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 229,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 230,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 231,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 232,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 233,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 234,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 235,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 236,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 237,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 238,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 239,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 240,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 241,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 242,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 243,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 244,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 245,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 246,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 247,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 248,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 249,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 250,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 251,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 252,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 253,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 254,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 255,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 256,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 257,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 258,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 259,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 260,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 261,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 262,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 263,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 264,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 265,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 266,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 267,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 268,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 269,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 270,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 271,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 272,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 273,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 274,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 275,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 276,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 277,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 278,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 279,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 280,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 281,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 282,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 283,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 284,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 285,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 286,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 287,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 288,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 289,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 290,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 291,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 292,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 293,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 294,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 295,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 296,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 297,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 298,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 299,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 300,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 301,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 302,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 303,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 304,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 305,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 306,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 307,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 308,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 309,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 310,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 311,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 312,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 313,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 314,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 315,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 316,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 317,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 318,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 319,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 320,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 321,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 322,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 323,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 324,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 325,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 326,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 327,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 328,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 329,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 330,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 331,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 332,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 333,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 334,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 335,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 336,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 337,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 338,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 339,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 340,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 341,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 342,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 343,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 344,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 345,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 346,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 347,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 348,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 349,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 350,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 351,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 352,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 353,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 354,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 355,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 356,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 357,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 358,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 359,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 360,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 361,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 362,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 363,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 364,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 365,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 366,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 367,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 368,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 369,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 370,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 371,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 372,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 373,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 374,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 375,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 376,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 377,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 378,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 379,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 380,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 381,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 382,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 383,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 384,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 385,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 386,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 387,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 388,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 389,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 390,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 391,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 392,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 393,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 394,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 395,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 396,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 397,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 398,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 399,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 400,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 401,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 402,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 403,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 404,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 405,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 406,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 407,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 408,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 409,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 410,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 411,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 412,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 413,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 414,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 415,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 416,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 417,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 418,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 419,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 420,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 421,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 422,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 423,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 424,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 425,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 426,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 427,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 428,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 429,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 430,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 431,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 432,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 433,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 434,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 435,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 436,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 437,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 438,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 439,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 440,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 441,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 442,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 443,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 444,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 445,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 446,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 447,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 448,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 449,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 450,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 451,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 452,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 453,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 454,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 455,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 456,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 457,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 458,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 459,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 460,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 461,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 462,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 463,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 464,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 465,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 466,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 467,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 468,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 469,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 470,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 471,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 472,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 473,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 474,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 475,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 476,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 477,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 478,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 479,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 480,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 481,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 482,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 483,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 484,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 485,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 486,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 487,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 488,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 489,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 490,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 491,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 492,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 493,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 494,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 495,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 496,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 497,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 498,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 499,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 500,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 501,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 502,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 503,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 504,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 505,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 506,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 507,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 508,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 509,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 510,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 511,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 512,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 513,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 514,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 515,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 516,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 517,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 518,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 519,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 520,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 521,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 522,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 523,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 524,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 525,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 526,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 527,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 528,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 529,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 530,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 531,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 532,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 533,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 534,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 535,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 536,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 537,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 538,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 539,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 540,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 541,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 542,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 543,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 544,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 545,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 546,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 547,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 548,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 549,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 550,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 551,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 552,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 553,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 554,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 555,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 556,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 557,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 558,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 559,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 560,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 561,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 562,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 563,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 564,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 565,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 566,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 567,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 568,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 569,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 570,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 571,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 572,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 573,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 574,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 575,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 576,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 577,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 578,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 579,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 580,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 581,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 582,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 583,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 584,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 585,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 586,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 587,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 588,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 589,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 590,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 591,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 592,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 593,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 594,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 595,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 596,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 597,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 598,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 599,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 600,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 601,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 602,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 603,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 604,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 605,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 606,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 607,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 608,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 609,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 610,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 611,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 612,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 613,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 614,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 615,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 616,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 617,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 618,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 619,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 620,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 621,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 622,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 623,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 624,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 625,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 626,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 627,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 628,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 629,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 630,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 631,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 632,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 633,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 634,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 635,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 636,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 637,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 638,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 639,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 640,
                column: "SeasonId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_TeamId",
                table: "PlayerTeams",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayerTeams_TeamId",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Advancement",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "LastRecordedWeek",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "SeasonStartDate",
                table: "Leagues");

            migrationBuilder.RenameColumn(
                name: "SeasonId",
                table: "Scorings",
                newName: "SeasonYear");

            migrationBuilder.AddColumn<int>(
                name: "Advancement",
                table: "Seasons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastRecordedWeek",
                table: "Seasons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RealSeason",
                table: "Seasons",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SeasonStartDate",
                table: "Seasons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TeamEndWeek",
                table: "PlayerTeams",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3205a74c-504f-498a-98dd-c6272fe313e1", "AQAAAAIAAYagAAAAEG6k1wuV+WNxIkaKw/Ji0g1uKp1pKuRCkb6lhlcvzyamUhCZK/BjGrNMCUYCDolo4Q==", "6e2d7c53-2344-49b5-861a-69947f6621ae" });

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 1,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 2,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 3,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 4,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 5,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 6,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 7,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 8,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 9,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 10,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 11,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 12,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 13,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 14,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 15,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 16,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 17,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 18,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 19,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 20,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 21,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 22,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 23,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 24,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 25,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 26,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 27,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 28,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 29,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 30,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 31,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 32,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 33,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 34,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 35,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 36,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 37,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 38,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 39,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 40,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 41,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 42,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 43,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 44,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 45,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 46,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 47,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 48,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 49,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 50,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 51,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 52,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 53,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 54,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 55,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 56,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 57,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 58,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 59,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 60,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 61,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 62,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 63,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 64,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 65,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 66,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 67,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 68,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 69,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 70,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 71,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 72,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 73,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 74,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 75,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 76,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 77,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 78,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 79,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 80,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 81,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 82,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 83,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 84,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 85,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 86,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 87,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 88,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 89,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 90,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 91,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 92,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 93,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 94,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 95,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 96,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 97,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 98,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 99,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 100,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 101,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 102,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 103,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 104,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 105,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 106,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 107,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 108,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 109,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 110,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 111,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 112,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 113,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 114,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 115,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 116,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 117,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 118,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 119,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 120,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 121,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 122,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 123,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 124,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 125,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 126,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 127,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 128,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 129,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 130,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 131,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 132,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 133,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 134,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 135,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 136,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 137,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 138,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 139,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 140,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 141,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 142,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 143,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 144,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 145,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 146,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 147,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 148,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 149,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 150,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 151,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 152,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 153,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 154,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 155,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 156,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 157,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 158,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 159,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 160,
                column: "TeamEndWeek",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 1,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 2,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 3,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 4,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 5,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 6,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 7,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 8,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 9,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 10,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 11,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 12,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 13,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 14,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 15,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 16,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 17,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 18,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 19,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 20,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 21,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 22,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 23,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 24,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 25,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 26,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 27,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 28,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 29,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 30,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 31,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 32,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 33,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 34,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 35,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 36,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 37,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 38,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 39,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 40,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 41,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 42,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 43,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 44,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 45,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 46,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 47,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 48,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 49,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 50,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 51,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 52,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 53,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 54,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 55,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 56,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 57,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 58,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 59,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 60,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 61,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 62,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 63,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 64,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 65,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 66,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 67,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 68,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 69,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 70,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 71,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 72,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 73,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 74,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 75,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 76,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 77,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 78,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 79,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 80,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 81,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 82,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 83,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 84,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 85,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 86,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 87,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 88,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 89,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 90,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 91,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 92,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 93,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 94,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 95,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 96,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 97,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 98,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 99,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 100,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 101,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 102,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 103,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 104,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 105,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 106,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 107,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 108,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 109,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 110,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 111,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 112,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 113,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 114,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 115,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 116,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 117,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 118,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 119,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 120,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 121,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 122,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 123,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 124,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 125,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 126,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 127,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 128,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 129,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 130,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 131,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 132,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 133,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 134,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 135,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 136,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 137,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 138,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 139,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 140,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 141,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 142,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 143,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 144,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 145,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 146,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 147,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 148,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 149,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 150,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 151,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 152,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 153,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 154,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 155,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 156,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 157,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 158,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 159,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 160,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 161,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 162,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 163,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 164,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 165,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 166,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 167,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 168,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 169,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 170,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 171,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 172,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 173,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 174,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 175,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 176,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 177,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 178,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 179,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 180,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 181,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 182,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 183,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 184,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 185,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 186,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 187,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 188,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 189,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 190,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 191,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 192,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 193,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 194,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 195,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 196,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 197,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 198,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 199,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 200,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 201,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 202,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 203,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 204,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 205,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 206,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 207,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 208,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 209,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 210,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 211,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 212,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 213,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 214,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 215,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 216,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 217,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 218,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 219,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 220,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 221,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 222,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 223,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 224,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 225,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 226,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 227,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 228,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 229,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 230,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 231,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 232,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 233,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 234,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 235,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 236,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 237,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 238,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 239,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 240,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 241,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 242,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 243,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 244,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 245,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 246,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 247,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 248,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 249,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 250,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 251,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 252,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 253,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 254,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 255,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 256,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 257,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 258,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 259,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 260,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 261,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 262,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 263,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 264,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 265,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 266,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 267,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 268,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 269,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 270,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 271,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 272,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 273,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 274,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 275,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 276,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 277,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 278,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 279,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 280,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 281,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 282,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 283,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 284,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 285,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 286,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 287,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 288,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 289,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 290,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 291,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 292,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 293,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 294,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 295,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 296,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 297,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 298,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 299,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 300,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 301,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 302,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 303,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 304,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 305,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 306,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 307,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 308,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 309,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 310,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 311,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 312,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 313,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 314,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 315,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 316,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 317,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 318,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 319,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 320,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 321,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 322,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 323,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 324,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 325,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 326,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 327,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 328,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 329,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 330,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 331,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 332,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 333,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 334,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 335,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 336,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 337,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 338,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 339,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 340,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 341,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 342,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 343,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 344,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 345,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 346,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 347,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 348,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 349,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 350,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 351,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 352,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 353,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 354,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 355,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 356,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 357,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 358,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 359,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 360,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 361,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 362,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 363,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 364,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 365,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 366,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 367,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 368,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 369,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 370,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 371,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 372,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 373,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 374,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 375,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 376,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 377,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 378,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 379,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 380,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 381,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 382,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 383,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 384,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 385,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 386,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 387,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 388,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 389,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 390,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 391,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 392,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 393,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 394,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 395,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 396,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 397,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 398,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 399,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 400,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 401,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 402,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 403,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 404,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 405,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 406,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 407,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 408,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 409,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 410,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 411,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 412,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 413,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 414,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 415,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 416,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 417,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 418,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 419,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 420,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 421,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 422,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 423,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 424,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 425,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 426,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 427,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 428,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 429,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 430,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 431,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 432,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 433,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 434,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 435,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 436,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 437,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 438,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 439,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 440,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 441,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 442,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 443,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 444,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 445,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 446,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 447,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 448,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 449,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 450,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 451,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 452,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 453,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 454,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 455,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 456,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 457,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 458,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 459,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 460,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 461,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 462,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 463,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 464,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 465,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 466,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 467,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 468,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 469,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 470,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 471,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 472,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 473,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 474,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 475,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 476,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 477,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 478,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 479,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 480,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 481,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 482,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 483,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 484,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 485,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 486,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 487,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 488,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 489,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 490,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 491,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 492,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 493,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 494,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 495,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 496,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 497,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 498,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 499,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 500,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 501,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 502,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 503,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 504,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 505,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 506,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 507,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 508,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 509,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 510,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 511,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 512,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 513,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 514,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 515,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 516,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 517,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 518,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 519,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 520,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 521,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 522,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 523,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 524,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 525,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 526,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 527,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 528,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 529,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 530,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 531,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 532,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 533,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 534,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 535,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 536,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 537,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 538,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 539,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 540,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 541,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 542,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 543,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 544,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 545,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 546,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 547,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 548,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 549,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 550,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 551,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 552,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 553,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 554,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 555,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 556,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 557,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 558,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 559,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 560,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 561,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 562,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 563,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 564,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 565,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 566,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 567,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 568,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 569,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 570,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 571,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 572,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 573,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 574,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 575,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 576,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 577,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 578,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 579,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 580,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 581,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 582,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 583,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 584,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 585,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 586,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 587,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 588,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 589,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 590,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 591,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 592,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 593,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 594,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 595,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 596,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 597,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 598,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 599,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 600,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 601,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 602,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 603,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 604,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 605,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 606,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 607,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 608,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 609,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 610,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 611,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 612,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 613,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 614,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 615,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 616,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 617,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 618,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 619,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 620,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 621,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 622,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 623,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 624,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 625,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 626,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 627,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 628,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 629,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 630,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 631,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 632,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 633,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 634,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 635,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 636,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 637,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 638,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 639,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 640,
                column: "SeasonYear",
                value: 2025);

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "SeasonId",
                keyValue: 1,
                columns: new[] { "Advancement", "LastRecordedWeek", "RealSeason", "SeasonStartDate" },
                values: new object[] { 0, 1, false, new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_TeamId_TeamStartWeek_TeamEndWeek",
                table: "PlayerTeams",
                columns: new[] { "TeamId", "TeamStartWeek", "TeamEndWeek" });
        }
    }
}
