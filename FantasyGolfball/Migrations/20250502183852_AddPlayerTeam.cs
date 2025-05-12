using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RosterPlayers",
                keyColumn: "RosterPlayerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RosterPlayers",
                keyColumn: "RosterPlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RosterPlayers",
                keyColumn: "RosterPlayerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RosterPlayers",
                keyColumn: "RosterPlayerId",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "ByeWeek",
                table: "Teams",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "PlayerTeams",
                columns: table => new
                {
                    PlayerTeamId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamStartWeek = table.Column<int>(type: "integer", nullable: false),
                    TeamEndWeek = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeams", x => x.PlayerTeamId);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3205a74c-504f-498a-98dd-c6272fe313e1", "AQAAAAIAAYagAAAAEG6k1wuV+WNxIkaKw/Ji0g1uKp1pKuRCkb6lhlcvzyamUhCZK/BjGrNMCUYCDolo4Q==", "6e2d7c53-2344-49b5-861a-69947f6621ae" });

            migrationBuilder.InsertData(
                table: "PlayerTeams",
                columns: new[] { "PlayerTeamId", "PlayerId", "TeamEndWeek", "TeamId", "TeamStartWeek" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1 },
                    { 2, 2, null, 2, 1 },
                    { 3, 3, null, 3, 1 },
                    { 4, 4, null, 4, 1 },
                    { 5, 5, null, 5, 1 },
                    { 6, 6, null, 6, 1 },
                    { 7, 7, null, 7, 1 },
                    { 8, 8, null, 8, 1 },
                    { 9, 9, null, 9, 1 },
                    { 10, 10, null, 10, 1 },
                    { 11, 11, null, 11, 1 },
                    { 12, 12, null, 12, 1 },
                    { 13, 13, null, 13, 1 },
                    { 14, 14, null, 14, 1 },
                    { 15, 15, null, 15, 1 },
                    { 16, 16, null, 16, 1 },
                    { 17, 17, null, 17, 1 },
                    { 18, 18, null, 18, 1 },
                    { 19, 19, null, 19, 1 },
                    { 20, 20, null, 20, 1 },
                    { 21, 21, null, 1, 1 },
                    { 22, 22, null, 2, 1 },
                    { 23, 23, null, 3, 1 },
                    { 24, 24, null, 4, 1 },
                    { 25, 25, null, 5, 1 },
                    { 26, 26, null, 6, 1 },
                    { 27, 27, null, 7, 1 },
                    { 28, 28, null, 8, 1 },
                    { 29, 29, null, 9, 1 },
                    { 30, 30, null, 10, 1 },
                    { 31, 31, null, 11, 1 },
                    { 32, 32, null, 12, 1 },
                    { 33, 33, null, 13, 1 },
                    { 34, 34, null, 14, 1 },
                    { 35, 35, null, 15, 1 },
                    { 36, 36, null, 16, 1 },
                    { 37, 37, null, 17, 1 },
                    { 38, 38, null, 18, 1 },
                    { 39, 39, null, 19, 1 },
                    { 40, 40, null, 20, 1 },
                    { 41, 41, null, 1, 1 },
                    { 42, 42, null, 2, 1 },
                    { 43, 43, null, 3, 1 },
                    { 44, 44, null, 4, 1 },
                    { 45, 45, null, 5, 1 },
                    { 46, 46, null, 6, 1 },
                    { 47, 47, null, 7, 1 },
                    { 48, 48, null, 8, 1 },
                    { 49, 49, null, 9, 1 },
                    { 50, 50, null, 10, 1 },
                    { 51, 51, null, 11, 1 },
                    { 52, 52, null, 12, 1 },
                    { 53, 53, null, 13, 1 },
                    { 54, 54, null, 14, 1 },
                    { 55, 55, null, 15, 1 },
                    { 56, 56, null, 16, 1 },
                    { 57, 57, null, 17, 1 },
                    { 58, 58, null, 18, 1 },
                    { 59, 59, null, 19, 1 },
                    { 60, 60, null, 20, 1 },
                    { 61, 61, null, 1, 1 },
                    { 62, 62, null, 2, 1 },
                    { 63, 63, null, 3, 1 },
                    { 64, 64, null, 4, 1 },
                    { 65, 65, null, 5, 1 },
                    { 66, 66, null, 6, 1 },
                    { 67, 67, null, 7, 1 },
                    { 68, 68, null, 8, 1 },
                    { 69, 69, null, 9, 1 },
                    { 70, 70, null, 10, 1 },
                    { 71, 71, null, 11, 1 },
                    { 72, 72, null, 12, 1 },
                    { 73, 73, null, 13, 1 },
                    { 74, 74, null, 14, 1 },
                    { 75, 75, null, 15, 1 },
                    { 76, 76, null, 16, 1 },
                    { 77, 77, null, 17, 1 },
                    { 78, 78, null, 18, 1 },
                    { 79, 79, null, 19, 1 },
                    { 80, 80, null, 20, 1 },
                    { 81, 81, null, 1, 1 },
                    { 82, 82, null, 2, 1 },
                    { 83, 83, null, 3, 1 },
                    { 84, 84, null, 4, 1 },
                    { 85, 85, null, 5, 1 },
                    { 86, 86, null, 6, 1 },
                    { 87, 87, null, 7, 1 },
                    { 88, 88, null, 8, 1 },
                    { 89, 89, null, 9, 1 },
                    { 90, 90, null, 10, 1 },
                    { 91, 91, null, 11, 1 },
                    { 92, 92, null, 12, 1 },
                    { 93, 93, null, 13, 1 },
                    { 94, 94, null, 14, 1 },
                    { 95, 95, null, 15, 1 },
                    { 96, 96, null, 16, 1 },
                    { 97, 97, null, 17, 1 },
                    { 98, 98, null, 18, 1 },
                    { 99, 99, null, 19, 1 },
                    { 100, 100, null, 20, 1 },
                    { 101, 101, null, 1, 1 },
                    { 102, 102, null, 2, 1 },
                    { 103, 103, null, 3, 1 },
                    { 104, 104, null, 4, 1 },
                    { 105, 105, null, 5, 1 },
                    { 106, 106, null, 6, 1 },
                    { 107, 107, null, 7, 1 },
                    { 108, 108, null, 8, 1 },
                    { 109, 109, null, 9, 1 },
                    { 110, 110, null, 10, 1 },
                    { 111, 111, null, 11, 1 },
                    { 112, 112, null, 12, 1 },
                    { 113, 113, null, 13, 1 },
                    { 114, 114, null, 14, 1 },
                    { 115, 115, null, 15, 1 },
                    { 116, 116, null, 16, 1 },
                    { 117, 117, null, 17, 1 },
                    { 118, 118, null, 18, 1 },
                    { 119, 119, null, 19, 1 },
                    { 120, 120, null, 20, 1 },
                    { 121, 121, null, 1, 1 },
                    { 122, 122, null, 2, 1 },
                    { 123, 123, null, 3, 1 },
                    { 124, 124, null, 4, 1 },
                    { 125, 125, null, 5, 1 },
                    { 126, 126, null, 6, 1 },
                    { 127, 127, null, 7, 1 },
                    { 128, 128, null, 8, 1 },
                    { 129, 129, null, 9, 1 },
                    { 130, 130, null, 10, 1 },
                    { 131, 131, null, 11, 1 },
                    { 132, 132, null, 12, 1 },
                    { 133, 133, null, 13, 1 },
                    { 134, 134, null, 14, 1 },
                    { 135, 135, null, 15, 1 },
                    { 136, 136, null, 16, 1 },
                    { 137, 137, null, 17, 1 },
                    { 138, 138, null, 18, 1 },
                    { 139, 139, null, 19, 1 },
                    { 140, 140, null, 20, 1 },
                    { 141, 141, null, 1, 1 },
                    { 142, 142, null, 2, 1 },
                    { 143, 143, null, 3, 1 },
                    { 144, 144, null, 4, 1 },
                    { 145, 145, null, 5, 1 },
                    { 146, 146, null, 6, 1 },
                    { 147, 147, null, 7, 1 },
                    { 148, 148, null, 8, 1 },
                    { 149, 149, null, 9, 1 },
                    { 150, 150, null, 10, 1 },
                    { 151, 151, null, 11, 1 },
                    { 152, 152, null, 12, 1 },
                    { 153, 153, null, 13, 1 },
                    { 154, 154, null, 14, 1 },
                    { 155, 155, null, 15, 1 },
                    { 156, 156, null, 16, 1 },
                    { 157, 157, null, 17, 1 },
                    { 158, 158, null, 18, 1 },
                    { 159, 159, null, 19, 1 },
                    { 160, 160, null, 20, 1 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_PlayerId_TeamStartWeek",
                table: "PlayerTeams",
                columns: new[] { "PlayerId", "TeamStartWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_TeamId_TeamStartWeek_TeamEndWeek",
                table: "PlayerTeams",
                columns: new[] { "TeamId", "TeamStartWeek", "TeamEndWeek" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTeams");

            migrationBuilder.AlterColumn<int>(
                name: "ByeWeek",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bade97b1-f77c-46ef-ad7e-21c1ad77f05d", "AQAAAAIAAYagAAAAEGQDOHlM98BcxzyFCIF8kVcbjizlTtEn4xxH0RFMrKxuDUTmveVqGEKquYo6xzPp/A==", "2734d54b-2a54-4597-a907-bb376b0842c8" });

            migrationBuilder.InsertData(
                table: "RosterPlayers",
                columns: new[] { "RosterPlayerId", "PlayerId", "RosterId", "RosterPosition" },
                values: new object[,]
                {
                    { 1, 1, 1, "bench" },
                    { 2, 21, 1, "bench" },
                    { 3, 41, 1, "bench" },
                    { 4, 71, 1, "bench" }
                });

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 1,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 2,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 3,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 4,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 5,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 6,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 7,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 8,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 9,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 10,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 11,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 12,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 13,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 14,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 15,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 16,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 17,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 18,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 19,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 20,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 21,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 22,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 23,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 24,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 25,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 26,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 27,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 28,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 29,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 30,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 31,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 32,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 33,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 34,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 35,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 36,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 37,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 38,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 39,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 40,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 41,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 42,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 43,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 44,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 45,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 46,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 47,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 48,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 49,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 50,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 51,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 52,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 53,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 54,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 55,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 56,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 57,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 58,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 59,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 60,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 61,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 62,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 63,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 64,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 65,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 66,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 67,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 68,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 69,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 70,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 71,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 72,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 73,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 74,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 75,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 76,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 77,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 78,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 79,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 80,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 81,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 82,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 83,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 84,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 85,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 86,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 87,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 88,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 89,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 90,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 91,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 92,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 93,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 94,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 95,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 96,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 97,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 98,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 99,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 100,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 101,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 102,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 103,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 104,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 105,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 106,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 107,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 108,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 109,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 110,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 111,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 112,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 113,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 114,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 115,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 116,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 117,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 118,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 119,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 120,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 121,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 122,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 123,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 124,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 125,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 126,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 127,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 128,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 129,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 130,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 131,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 132,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 133,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 134,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 135,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 136,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 137,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 138,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 139,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 140,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 141,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 142,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 143,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 144,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 145,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 146,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 147,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 148,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 149,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 150,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 151,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 152,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 153,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 154,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 155,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 156,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 157,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 158,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 159,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 160,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 161,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 162,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 163,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 164,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 165,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 166,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 167,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 168,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 169,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 170,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 171,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 172,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 173,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 174,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 175,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 176,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 177,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 178,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 179,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 180,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 181,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 182,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 183,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 184,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 185,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 186,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 187,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 188,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 189,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 190,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 191,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 192,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 193,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 194,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 195,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 196,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 197,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 198,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 199,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 200,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 201,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 202,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 203,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 204,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 205,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 206,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 207,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 208,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 209,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 210,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 211,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 212,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 213,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 214,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 215,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 216,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 217,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 218,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 219,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 220,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 221,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 222,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 223,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 224,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 225,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 226,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 227,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 228,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 229,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 230,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 231,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 232,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 233,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 234,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 235,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 236,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 237,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 238,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 239,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 240,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 241,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 242,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 243,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 244,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 245,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 246,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 247,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 248,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 249,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 250,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 251,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 252,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 253,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 254,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 255,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 256,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 257,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 258,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 259,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 260,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 261,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 262,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 263,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 264,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 265,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 266,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 267,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 268,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 269,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 270,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 271,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 272,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 273,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 274,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 275,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 276,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 277,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 278,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 279,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 280,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 281,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 282,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 283,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 284,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 285,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 286,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 287,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 288,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 289,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 290,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 291,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 292,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 293,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 294,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 295,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 296,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 297,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 298,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 299,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 300,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 301,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 302,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 303,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 304,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 305,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 306,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 307,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 308,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 309,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 310,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 311,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 312,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 313,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 314,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 315,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 316,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 317,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 318,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 319,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 320,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 321,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 322,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 323,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 324,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 325,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 326,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 327,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 328,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 329,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 330,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 331,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 332,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 333,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 334,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 335,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 336,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 337,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 338,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 339,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 340,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 341,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 342,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 343,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 344,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 345,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 346,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 347,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 348,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 349,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 350,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 351,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 352,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 353,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 354,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 355,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 356,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 357,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 358,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 359,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 360,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 361,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 362,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 363,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 364,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 365,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 366,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 367,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 368,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 369,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 370,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 371,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 372,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 373,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 374,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 375,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 376,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 377,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 378,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 379,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 380,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 381,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 382,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 383,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 384,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 385,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 386,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 387,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 388,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 389,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 390,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 391,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 392,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 393,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 394,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 395,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 396,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 397,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 398,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 399,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 400,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 401,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 402,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 403,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 404,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 405,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 406,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 407,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 408,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 409,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 410,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 411,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 412,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 413,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 414,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 415,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 416,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 417,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 418,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 419,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 420,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 421,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 422,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 423,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 424,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 425,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 426,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 427,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 428,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 429,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 430,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 431,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 432,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 433,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 434,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 435,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 436,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 437,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 438,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 439,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 440,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 441,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 442,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 443,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 444,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 445,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 446,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 447,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 448,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 449,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 450,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 451,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 452,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 453,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 454,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 455,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 456,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 457,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 458,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 459,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 460,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 461,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 462,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 463,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 464,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 465,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 466,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 467,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 468,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 469,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 470,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 471,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 472,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 473,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 474,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 475,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 476,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 477,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 478,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 479,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 480,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 481,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 482,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 483,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 484,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 485,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 486,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 487,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 488,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 489,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 490,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 491,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 492,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 493,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 494,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 495,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 496,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 497,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 498,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 499,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 500,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 501,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 502,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 503,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 504,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 505,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 506,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 507,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 508,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 509,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 510,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 511,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 512,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 513,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 514,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 515,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 516,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 517,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 518,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 519,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 520,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 521,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 522,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 523,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 524,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 525,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 526,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 527,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 528,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 529,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 530,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 531,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 532,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 533,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 534,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 535,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 536,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 537,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 538,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 539,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 540,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 541,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 542,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 543,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 544,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 545,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 546,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 547,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 548,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 549,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 550,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 551,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 552,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 553,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 554,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 555,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 556,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 557,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 558,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 559,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 560,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 561,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 562,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 563,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 564,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 565,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 566,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 567,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 568,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 569,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 570,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 571,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 572,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 573,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 574,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 575,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 576,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 577,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 578,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 579,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 580,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 581,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 582,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 583,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 584,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 585,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 586,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 587,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 588,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 589,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 590,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 591,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 592,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 593,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 594,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 595,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 596,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 597,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 598,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 599,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 600,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 601,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 602,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 603,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 604,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 605,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 606,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 607,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 608,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 609,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 610,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 611,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 612,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 613,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 614,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 615,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 616,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 617,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 618,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 619,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 620,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 621,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 622,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 623,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 624,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 625,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 626,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 627,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 628,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 629,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 630,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 631,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 632,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 633,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 634,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 635,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 636,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 637,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 638,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 639,
                column: "SeasonYear",
                value: 2024);

            migrationBuilder.UpdateData(
                table: "Scorings",
                keyColumn: "ScoringId",
                keyValue: 640,
                column: "SeasonYear",
                value: 2024);
        }
    }
}
