using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerScoreTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewPlayerTestPlayerId",
                table: "RosterPlayers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewPlayerTestPlayerId",
                table: "PlayerTeams",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewPlayerTestPlayerId",
                table: "PlayerStatuses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NewPlayerTests",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerFirstName = table.Column<string>(type: "text", nullable: false),
                    PlayerLastName = table.Column<string>(type: "text", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false),
                    SeasonId = table.Column<int>(type: "integer", nullable: false),
                    GamesPlayed = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewPlayerTests", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_NewPlayerTests_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewScoringTests",
                columns: table => new
                {
                    ScoringId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonId = table.Column<int>(type: "integer", nullable: false),
                    SeasonWeek = table.Column<int>(type: "integer", nullable: false),
                    IsDefense = table.Column<bool>(type: "boolean", nullable: false),
                    Completions = table.Column<int>(type: "integer", nullable: true),
                    AttemptsPassing = table.Column<int>(type: "integer", nullable: true),
                    YardsPassing = table.Column<int>(type: "integer", nullable: true),
                    TouchdownsPassing = table.Column<int>(type: "integer", nullable: true),
                    Interceptions = table.Column<int>(type: "integer", nullable: true),
                    Targets = table.Column<int>(type: "integer", nullable: true),
                    Receptions = table.Column<int>(type: "integer", nullable: true),
                    AttemptsRushing = table.Column<int>(type: "integer", nullable: true),
                    YardsRushing = table.Column<int>(type: "integer", nullable: true),
                    TouchdownsRushing = table.Column<int>(type: "integer", nullable: true),
                    Fumbles = table.Column<int>(type: "integer", nullable: true),
                    FumbleLost = table.Column<int>(type: "integer", nullable: true),
                    TwoExtraPoints = table.Column<int>(type: "integer", nullable: true),
                    FieldGoalAttempts = table.Column<int>(type: "integer", nullable: true),
                    FieldGoalsMade = table.Column<int>(type: "integer", nullable: true),
                    PointsAgainst = table.Column<int>(type: "integer", nullable: true),
                    Sacks = table.Column<int>(type: "integer", nullable: true),
                    InterceptionDefense = table.Column<int>(type: "integer", nullable: true),
                    DefenseFumbleRecovery = table.Column<int>(type: "integer", nullable: true),
                    Safety = table.Column<int>(type: "integer", nullable: true),
                    TouchdownsDefense = table.Column<int>(type: "integer", nullable: true),
                    TouchdownsReturn = table.Column<int>(type: "integer", nullable: true),
                    NewPlayerTestPlayerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewScoringTests", x => x.ScoringId);
                    table.ForeignKey(
                        name: "FK_NewScoringTests_NewPlayerTests_NewPlayerTestPlayerId",
                        column: x => x.NewPlayerTestPlayerId,
                        principalTable: "NewPlayerTests",
                        principalColumn: "PlayerId");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ad482bf-db5f-458e-acc7-9f627849b555", "AQAAAAIAAYagAAAAEEMCNS7pVGdKTlrLp56MHK/RG4L8ju+yJlu2Yt2sJ5uPllC4omVWT1AGJohyATXPMQ==", "1ef066fc-857e-4cde-8e65-44ab9e9ed98d" });

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 1,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 2,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 3,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 4,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 5,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 6,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 7,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 8,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 9,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 10,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 11,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 12,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 13,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 14,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 15,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 16,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 17,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 18,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 19,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 20,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 21,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 22,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 23,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 24,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 25,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 26,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 27,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 28,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 29,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 30,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 31,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 32,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 33,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 34,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 35,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 36,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 37,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 38,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 39,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 40,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 41,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 42,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 43,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 44,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 45,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 46,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 47,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 48,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 49,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 50,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 51,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 52,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 53,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 54,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 55,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 56,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 57,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 58,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 59,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 60,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 61,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 62,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 63,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 64,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 65,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 66,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 67,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 68,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 69,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 70,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 71,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 72,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 73,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 74,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 75,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 76,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 77,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 78,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 79,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 80,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 81,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 82,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 83,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 84,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 85,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 86,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 87,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 88,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 89,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 90,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 91,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 92,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 93,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 94,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 95,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 96,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 97,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 98,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 99,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 100,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 101,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 102,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 103,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 104,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 105,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 106,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 107,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 108,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 109,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 110,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 111,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 112,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 113,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 114,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 115,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 116,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 117,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 118,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 119,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 120,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 121,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 122,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 123,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 124,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 125,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 126,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 127,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 128,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 129,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 130,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 131,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 132,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 133,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 134,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 135,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 136,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 137,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 138,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 139,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 140,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 141,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 142,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 143,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 144,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 145,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 146,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 147,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 148,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 149,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 150,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 151,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 152,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 153,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 154,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 155,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 156,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 157,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 158,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 159,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerStatuses",
                keyColumn: "PlayerStatusId",
                keyValue: 160,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 1,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 2,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 3,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 4,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 5,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 6,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 7,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 8,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 9,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 10,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 11,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 12,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 13,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 14,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 15,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 16,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 17,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 18,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 19,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 20,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 21,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 22,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 23,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 24,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 25,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 26,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 27,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 28,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 29,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 30,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 31,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 32,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 33,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 34,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 35,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 36,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 37,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 38,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 39,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 40,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 41,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 42,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 43,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 44,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 45,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 46,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 47,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 48,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 49,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 50,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 51,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 52,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 53,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 54,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 55,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 56,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 57,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 58,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 59,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 60,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 61,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 62,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 63,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 64,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 65,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 66,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 67,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 68,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 69,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 70,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 71,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 72,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 73,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 74,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 75,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 76,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 77,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 78,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 79,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 80,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 81,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 82,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 83,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 84,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 85,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 86,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 87,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 88,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 89,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 90,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 91,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 92,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 93,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 94,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 95,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 96,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 97,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 98,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 99,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 100,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 101,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 102,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 103,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 104,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 105,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 106,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 107,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 108,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 109,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 110,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 111,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 112,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 113,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 114,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 115,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 116,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 117,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 118,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 119,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 120,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 121,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 122,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 123,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 124,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 125,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 126,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 127,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 128,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 129,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 130,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 131,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 132,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 133,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 134,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 135,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 136,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 137,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 138,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 139,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 140,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 141,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 142,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 143,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 144,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 145,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 146,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 147,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 148,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 149,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 150,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 151,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 152,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 153,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 154,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 155,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 156,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 157,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 158,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 159,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PlayerTeams",
                keyColumn: "PlayerTeamId",
                keyValue: 160,
                column: "NewPlayerTestPlayerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_RosterPlayers_NewPlayerTestPlayerId",
                table: "RosterPlayers",
                column: "NewPlayerTestPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_NewPlayerTestPlayerId",
                table: "PlayerTeams",
                column: "NewPlayerTestPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatuses_NewPlayerTestPlayerId",
                table: "PlayerStatuses",
                column: "NewPlayerTestPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_NewPlayerTests_PositionId",
                table: "NewPlayerTests",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_NewScoringTests_NewPlayerTestPlayerId",
                table: "NewScoringTests",
                column: "NewPlayerTestPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatuses_NewPlayerTests_NewPlayerTestPlayerId",
                table: "PlayerStatuses",
                column: "NewPlayerTestPlayerId",
                principalTable: "NewPlayerTests",
                principalColumn: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerTeams_NewPlayerTests_NewPlayerTestPlayerId",
                table: "PlayerTeams",
                column: "NewPlayerTestPlayerId",
                principalTable: "NewPlayerTests",
                principalColumn: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RosterPlayers_NewPlayerTests_NewPlayerTestPlayerId",
                table: "RosterPlayers",
                column: "NewPlayerTestPlayerId",
                principalTable: "NewPlayerTests",
                principalColumn: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatuses_NewPlayerTests_NewPlayerTestPlayerId",
                table: "PlayerStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerTeams_NewPlayerTests_NewPlayerTestPlayerId",
                table: "PlayerTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_RosterPlayers_NewPlayerTests_NewPlayerTestPlayerId",
                table: "RosterPlayers");

            migrationBuilder.DropTable(
                name: "NewScoringTests");

            migrationBuilder.DropTable(
                name: "NewPlayerTests");

            migrationBuilder.DropIndex(
                name: "IX_RosterPlayers_NewPlayerTestPlayerId",
                table: "RosterPlayers");

            migrationBuilder.DropIndex(
                name: "IX_PlayerTeams_NewPlayerTestPlayerId",
                table: "PlayerTeams");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStatuses_NewPlayerTestPlayerId",
                table: "PlayerStatuses");

            migrationBuilder.DropColumn(
                name: "NewPlayerTestPlayerId",
                table: "RosterPlayers");

            migrationBuilder.DropColumn(
                name: "NewPlayerTestPlayerId",
                table: "PlayerTeams");

            migrationBuilder.DropColumn(
                name: "NewPlayerTestPlayerId",
                table: "PlayerStatuses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9e05b38-7ab5-4b4a-bf01-d46e0ecd88d2", "AQAAAAIAAYagAAAAEO2n/n1K3CyR11/VYM7M+84jRYKiJkP+Lz+1ezLGerxh7Aw1HeiMndkM/csVciZsMA==", "8651d3d8-50d8-49fd-934f-0b6015007cb1" });
        }
    }
}
