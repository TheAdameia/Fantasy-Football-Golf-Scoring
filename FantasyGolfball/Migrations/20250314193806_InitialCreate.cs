using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerLimit = table.Column<int>(type: "integer", nullable: false),
                    RandomizedDraftOrder = table.Column<bool>(type: "boolean", nullable: false),
                    UsersVetoTrades = table.Column<bool>(type: "boolean", nullable: false),
                    LeagueName = table.Column<string>(type: "text", nullable: false),
                    RequiredFullToStart = table.Column<bool>(type: "boolean", nullable: false),
                    MaxRosterSize = table.Column<int>(type: "integer", nullable: false),
                    IsDraftComplete = table.Column<bool>(type: "boolean", nullable: false),
                    SeasonId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Matchups",
                columns: table => new
                {
                    MatchupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeagueId = table.Column<int>(type: "integer", nullable: false),
                    WeekId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchups", x => x.MatchupId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PositionShort = table.Column<string>(type: "text", nullable: false),
                    PositionLong = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Rosters",
                columns: table => new
                {
                    RosterId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeagueId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rosters", x => x.RosterId);
                });

            migrationBuilder.CreateTable(
                name: "Scorings",
                columns: table => new
                {
                    ScoringId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    SeasonYear = table.Column<int>(type: "integer", nullable: false),
                    SeasonWeek = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scorings", x => x.ScoringId);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SeasonYear = table.Column<int>(type: "integer", nullable: false),
                    SeasonStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RealSeason = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusType = table.Column<string>(type: "text", nullable: false),
                    ViableToPlay = table.Column<bool>(type: "boolean", nullable: false),
                    RequiresBackup = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamName = table.Column<string>(type: "text", nullable: false),
                    TeamCity = table.Column<string>(type: "text", nullable: false),
                    ByeWeek = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerFirstName = table.Column<string>(type: "text", nullable: false),
                    PlayerLastName = table.Column<string>(type: "text", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivePeriods",
                columns: table => new
                {
                    ActivePeriodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivePeriods", x => x.ActivePeriodId);
                    table.ForeignKey(
                        name: "FK_ActivePeriods_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeagueUsers",
                columns: table => new
                {
                    LeagueUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeagueId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    RosterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueUsers", x => x.LeagueUserId);
                    table.ForeignKey(
                        name: "FK_LeagueUsers_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueUsers_Rosters_RosterId",
                        column: x => x.RosterId,
                        principalTable: "Rosters",
                        principalColumn: "RosterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueUsers_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchupUsers",
                columns: table => new
                {
                    MatchupUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    MatchupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchupUsers", x => x.MatchupUserId);
                    table.ForeignKey(
                        name: "FK_MatchupUsers_Matchups_MatchupId",
                        column: x => x.MatchupId,
                        principalTable: "Matchups",
                        principalColumn: "MatchupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchupUsers_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RosterPlayers",
                columns: table => new
                {
                    RosterPlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    RosterId = table.Column<int>(type: "integer", nullable: false),
                    RosterPosition = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RosterPlayers", x => x.RosterPlayerId);
                    table.ForeignKey(
                        name: "FK_RosterPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RosterPlayers_Rosters_RosterId",
                        column: x => x.RosterId,
                        principalTable: "Rosters",
                        principalColumn: "RosterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "b8c4c4f3-5ea8-4e70-b67f-6f7010c85686", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEGlX7mQKaum16Iy8qFtIQxukWuTi0YlTfofXmQpZZag1vrL35xJrIJeyC3kTk1Ex2Q==", null, false, "fa4c5a5a-586b-4d7c-b1b1-98ceff37d8d5", false, "Administrator" });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "LeagueId", "IsDraftComplete", "LeagueName", "MaxRosterSize", "PlayerLimit", "RandomizedDraftOrder", "RequiredFullToStart", "SeasonId", "UsersVetoTrades" },
                values: new object[] { 1, false, "testing league", 15, 4, true, true, 1, true });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionId", "PositionLong", "PositionShort" },
                values: new object[,]
                {
                    { 1, "Quarterback", "QB" },
                    { 2, "Wide Receiver", "WR" },
                    { 3, "Running Back", "RB" },
                    { 4, "Tight End", "TE" },
                    { 5, "Kicker", "K" },
                    { 6, "Defense", "DEF" }
                });

            migrationBuilder.InsertData(
                table: "Rosters",
                columns: new[] { "RosterId", "LeagueId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Scorings",
                columns: new[] { "ScoringId", "PlayerId", "Points", "SeasonWeek", "SeasonYear" },
                values: new object[,]
                {
                    { 1, 1, 5.1f, 1, 2024 },
                    { 2, 1, 5.5f, 2, 2024 },
                    { 3, 1, 5.7f, 3, 2024 },
                    { 4, 1, 1.4f, 4, 2024 },
                    { 5, 2, -4.3f, 1, 2024 },
                    { 6, 2, 16.8f, 2, 2024 },
                    { 7, 2, 10.8f, 3, 2024 },
                    { 8, 2, 4.3f, 4, 2024 },
                    { 9, 3, 10f, 1, 2024 },
                    { 10, 3, 0.2f, 2, 2024 },
                    { 11, 3, -0.2f, 3, 2024 },
                    { 12, 3, -1.1f, 4, 2024 },
                    { 13, 4, 18.7f, 1, 2024 },
                    { 14, 4, 2.7f, 2, 2024 },
                    { 15, 4, 18.2f, 3, 2024 },
                    { 16, 4, 2.3f, 4, 2024 },
                    { 17, 5, 15.5f, 1, 2024 },
                    { 18, 5, 6.2f, 2, 2024 },
                    { 19, 5, 9.6f, 3, 2024 },
                    { 20, 5, -4.7f, 4, 2024 },
                    { 21, 6, 2.9f, 1, 2024 },
                    { 22, 6, 1.4f, 2, 2024 },
                    { 23, 6, 0.1f, 3, 2024 },
                    { 24, 6, 0.2f, 4, 2024 },
                    { 25, 7, -3.1f, 1, 2024 },
                    { 26, 7, 15f, 2, 2024 },
                    { 27, 7, -2.4f, 3, 2024 },
                    { 28, 7, 7.6f, 4, 2024 },
                    { 29, 8, 12.8f, 1, 2024 },
                    { 30, 8, 14f, 2, 2024 },
                    { 31, 8, 16.1f, 3, 2024 },
                    { 32, 8, 7.8f, 4, 2024 },
                    { 33, 9, 17.9f, 1, 2024 },
                    { 34, 9, 2.2f, 2, 2024 },
                    { 35, 9, -4.5f, 3, 2024 },
                    { 36, 9, -3.3f, 4, 2024 },
                    { 37, 10, 20f, 1, 2024 },
                    { 38, 10, -2.7f, 2, 2024 },
                    { 39, 10, 17.2f, 3, 2024 },
                    { 40, 10, 18.2f, 4, 2024 },
                    { 41, 11, 10.8f, 1, 2024 },
                    { 42, 11, 3.9f, 2, 2024 },
                    { 43, 11, -2.6f, 3, 2024 },
                    { 44, 11, 18.9f, 4, 2024 },
                    { 45, 12, 12.3f, 1, 2024 },
                    { 46, 12, 17f, 2, 2024 },
                    { 47, 12, 4.5f, 3, 2024 },
                    { 48, 12, -4f, 4, 2024 },
                    { 49, 13, -4.7f, 1, 2024 },
                    { 50, 13, -1.2f, 2, 2024 },
                    { 51, 13, 9.3f, 3, 2024 },
                    { 52, 13, 16.1f, 4, 2024 },
                    { 53, 14, 0.4f, 1, 2024 },
                    { 54, 14, 4.9f, 2, 2024 },
                    { 55, 14, -4.8f, 3, 2024 },
                    { 56, 14, 3.6f, 4, 2024 },
                    { 57, 15, 12.6f, 1, 2024 },
                    { 58, 15, -2.6f, 2, 2024 },
                    { 59, 15, 2.7f, 3, 2024 },
                    { 60, 15, 4.9f, 4, 2024 },
                    { 61, 16, 13.7f, 1, 2024 },
                    { 62, 16, -2.2f, 2, 2024 },
                    { 63, 16, 9.8f, 3, 2024 },
                    { 64, 16, 9.8f, 4, 2024 },
                    { 65, 17, 19.5f, 1, 2024 },
                    { 66, 17, 6.6f, 2, 2024 },
                    { 67, 17, 16.6f, 3, 2024 },
                    { 68, 17, 8.3f, 4, 2024 },
                    { 69, 18, -4.5f, 1, 2024 },
                    { 70, 18, 9.9f, 2, 2024 },
                    { 71, 18, 18.4f, 3, 2024 },
                    { 72, 18, -4.6f, 4, 2024 },
                    { 73, 19, -4.8f, 1, 2024 },
                    { 74, 19, 1.8f, 2, 2024 },
                    { 75, 19, 7.9f, 3, 2024 },
                    { 76, 19, 12.4f, 4, 2024 },
                    { 77, 20, 10.4f, 1, 2024 },
                    { 78, 20, -3.6f, 2, 2024 },
                    { 79, 20, 0.1f, 3, 2024 },
                    { 80, 20, -1.8f, 4, 2024 },
                    { 81, 21, 1.5f, 1, 2024 },
                    { 82, 21, 2.4f, 2, 2024 },
                    { 83, 21, 15.2f, 3, 2024 },
                    { 84, 21, 6.3f, 4, 2024 },
                    { 85, 22, 8.8f, 1, 2024 },
                    { 86, 22, 5.9f, 2, 2024 },
                    { 87, 22, 12.8f, 3, 2024 },
                    { 88, 22, 14.3f, 4, 2024 },
                    { 89, 23, 1.4f, 1, 2024 },
                    { 90, 23, 10.2f, 2, 2024 },
                    { 91, 23, 4.1f, 3, 2024 },
                    { 92, 23, 8.8f, 4, 2024 },
                    { 93, 24, 12.8f, 1, 2024 },
                    { 94, 24, 6.1f, 2, 2024 },
                    { 95, 24, 10.6f, 3, 2024 },
                    { 96, 24, -4.9f, 4, 2024 },
                    { 97, 25, 11.2f, 1, 2024 },
                    { 98, 25, -2.7f, 2, 2024 },
                    { 99, 25, -3.2f, 3, 2024 },
                    { 100, 25, 15.9f, 4, 2024 },
                    { 101, 26, 13.1f, 1, 2024 },
                    { 102, 26, 5.6f, 2, 2024 },
                    { 103, 26, 7.2f, 3, 2024 },
                    { 104, 26, 19.7f, 4, 2024 },
                    { 105, 27, 12.9f, 1, 2024 },
                    { 106, 27, -3f, 2, 2024 },
                    { 107, 27, 10.6f, 3, 2024 },
                    { 108, 27, 12.8f, 4, 2024 },
                    { 109, 28, -1.6f, 1, 2024 },
                    { 110, 28, 11f, 2, 2024 },
                    { 111, 28, -2.6f, 3, 2024 },
                    { 112, 28, 17.5f, 4, 2024 },
                    { 113, 29, 3.2f, 1, 2024 },
                    { 114, 29, 17.2f, 2, 2024 },
                    { 115, 29, 9.9f, 3, 2024 },
                    { 116, 29, 18.3f, 4, 2024 },
                    { 117, 30, 18.6f, 1, 2024 },
                    { 118, 30, -1.6f, 2, 2024 },
                    { 119, 30, 17f, 3, 2024 },
                    { 120, 30, 16.1f, 4, 2024 },
                    { 121, 31, 13.6f, 1, 2024 },
                    { 122, 31, -2.8f, 2, 2024 },
                    { 123, 31, 0.5f, 3, 2024 },
                    { 124, 31, -3.9f, 4, 2024 },
                    { 125, 32, -1.8f, 1, 2024 },
                    { 126, 32, -2.5f, 2, 2024 },
                    { 127, 32, -3.6f, 3, 2024 },
                    { 128, 32, 14.6f, 4, 2024 },
                    { 129, 33, 4.6f, 1, 2024 },
                    { 130, 33, 11.8f, 2, 2024 },
                    { 131, 33, -0.9f, 3, 2024 },
                    { 132, 33, 9.4f, 4, 2024 },
                    { 133, 34, 2.6f, 1, 2024 },
                    { 134, 34, 6f, 2, 2024 },
                    { 135, 34, -3.9f, 3, 2024 },
                    { 136, 34, -2.3f, 4, 2024 },
                    { 137, 35, 11.8f, 1, 2024 },
                    { 138, 35, 7.9f, 2, 2024 },
                    { 139, 35, 17.1f, 3, 2024 },
                    { 140, 35, 5.7f, 4, 2024 },
                    { 141, 36, 14.3f, 1, 2024 },
                    { 142, 36, 3.1f, 2, 2024 },
                    { 143, 36, -1.2f, 3, 2024 },
                    { 144, 36, 13.2f, 4, 2024 },
                    { 145, 37, 12f, 1, 2024 },
                    { 146, 37, 9.6f, 2, 2024 },
                    { 147, 37, 17.3f, 3, 2024 },
                    { 148, 37, 19.1f, 4, 2024 },
                    { 149, 38, -1.4f, 1, 2024 },
                    { 150, 38, 12.4f, 2, 2024 },
                    { 151, 38, 6.1f, 3, 2024 },
                    { 152, 38, 3.3f, 4, 2024 },
                    { 153, 39, 18.3f, 1, 2024 },
                    { 154, 39, 19.3f, 2, 2024 },
                    { 155, 39, -1.8f, 3, 2024 },
                    { 156, 39, 18.6f, 4, 2024 },
                    { 157, 40, 5.5f, 1, 2024 },
                    { 158, 40, 9.1f, 2, 2024 },
                    { 159, 40, 15.2f, 3, 2024 },
                    { 160, 40, 18.6f, 4, 2024 },
                    { 161, 41, 8.1f, 1, 2024 },
                    { 162, 41, 14.3f, 2, 2024 },
                    { 163, 41, 15.4f, 3, 2024 },
                    { 164, 41, 16.8f, 4, 2024 },
                    { 165, 42, 3.5f, 1, 2024 },
                    { 166, 42, 16.5f, 2, 2024 },
                    { 167, 42, 19.4f, 3, 2024 },
                    { 168, 42, 4.2f, 4, 2024 },
                    { 169, 43, 2.8f, 1, 2024 },
                    { 170, 43, 12f, 2, 2024 },
                    { 171, 43, 2.5f, 3, 2024 },
                    { 172, 43, -1.9f, 4, 2024 },
                    { 173, 44, -0.5f, 1, 2024 },
                    { 174, 44, 4f, 2, 2024 },
                    { 175, 44, 3.8f, 3, 2024 },
                    { 176, 44, 13f, 4, 2024 },
                    { 177, 45, 13.2f, 1, 2024 },
                    { 178, 45, 14.1f, 2, 2024 },
                    { 179, 45, 16.6f, 3, 2024 },
                    { 180, 45, 14.1f, 4, 2024 },
                    { 181, 46, 2.9f, 1, 2024 },
                    { 182, 46, 10.9f, 2, 2024 },
                    { 183, 46, 14.8f, 3, 2024 },
                    { 184, 46, 15.4f, 4, 2024 },
                    { 185, 47, 13.9f, 1, 2024 },
                    { 186, 47, 14.5f, 2, 2024 },
                    { 187, 47, -0.3f, 3, 2024 },
                    { 188, 47, -1f, 4, 2024 },
                    { 189, 48, 2.8f, 1, 2024 },
                    { 190, 48, 3.9f, 2, 2024 },
                    { 191, 48, 2.3f, 3, 2024 },
                    { 192, 48, 11f, 4, 2024 },
                    { 193, 49, -1.7f, 1, 2024 },
                    { 194, 49, 7.1f, 2, 2024 },
                    { 195, 49, 11f, 3, 2024 },
                    { 196, 49, 12.5f, 4, 2024 },
                    { 197, 50, 8.9f, 1, 2024 },
                    { 198, 50, 3.4f, 2, 2024 },
                    { 199, 50, 4.9f, 3, 2024 },
                    { 200, 50, 19.6f, 4, 2024 },
                    { 201, 51, 13.1f, 1, 2024 },
                    { 202, 51, -2.2f, 2, 2024 },
                    { 203, 51, 12.7f, 3, 2024 },
                    { 204, 51, 18.4f, 4, 2024 },
                    { 205, 52, 18.2f, 1, 2024 },
                    { 206, 52, -0.6f, 2, 2024 },
                    { 207, 52, 3.6f, 3, 2024 },
                    { 208, 52, 15.7f, 4, 2024 },
                    { 209, 53, -2.3f, 1, 2024 },
                    { 210, 53, 1.2f, 2, 2024 },
                    { 211, 53, 19.1f, 3, 2024 },
                    { 212, 53, 7.7f, 4, 2024 },
                    { 213, 54, 0.6f, 1, 2024 },
                    { 214, 54, 0.9f, 2, 2024 },
                    { 215, 54, 1.5f, 3, 2024 },
                    { 216, 54, -2.4f, 4, 2024 },
                    { 217, 55, 0.7f, 1, 2024 },
                    { 218, 55, -3.3f, 2, 2024 },
                    { 219, 55, 3.3f, 3, 2024 },
                    { 220, 55, 14.4f, 4, 2024 },
                    { 221, 56, -4.1f, 1, 2024 },
                    { 222, 56, 14.6f, 2, 2024 },
                    { 223, 56, 18.4f, 3, 2024 },
                    { 224, 56, -3.5f, 4, 2024 },
                    { 225, 57, 15f, 1, 2024 },
                    { 226, 57, 7.2f, 2, 2024 },
                    { 227, 57, -3.5f, 3, 2024 },
                    { 228, 57, 17f, 4, 2024 },
                    { 229, 58, 17f, 1, 2024 },
                    { 230, 58, 13f, 2, 2024 },
                    { 231, 58, 14.4f, 3, 2024 },
                    { 232, 58, -0.2f, 4, 2024 },
                    { 233, 59, 17.3f, 1, 2024 },
                    { 234, 59, 16.3f, 2, 2024 },
                    { 235, 59, -0.2f, 3, 2024 },
                    { 236, 59, 16.6f, 4, 2024 },
                    { 237, 60, 15.4f, 1, 2024 },
                    { 238, 60, 17f, 2, 2024 },
                    { 239, 60, 6f, 3, 2024 },
                    { 240, 60, 2.8f, 4, 2024 },
                    { 241, 61, -0.1f, 1, 2024 },
                    { 242, 61, 9.1f, 2, 2024 },
                    { 243, 61, 4.7f, 3, 2024 },
                    { 244, 61, 15.5f, 4, 2024 },
                    { 245, 62, 17.8f, 1, 2024 },
                    { 246, 62, 14.1f, 2, 2024 },
                    { 247, 62, 17f, 3, 2024 },
                    { 248, 62, -0.4f, 4, 2024 },
                    { 249, 63, 7f, 1, 2024 },
                    { 250, 63, 15.7f, 2, 2024 },
                    { 251, 63, 15.2f, 3, 2024 },
                    { 252, 63, 5.3f, 4, 2024 },
                    { 253, 64, 4.7f, 1, 2024 },
                    { 254, 64, 19.5f, 2, 2024 },
                    { 255, 64, 9.1f, 3, 2024 },
                    { 256, 64, 6.9f, 4, 2024 },
                    { 257, 65, 10.1f, 1, 2024 },
                    { 258, 65, -4.3f, 2, 2024 },
                    { 259, 65, -0.9f, 3, 2024 },
                    { 260, 65, 10.7f, 4, 2024 },
                    { 261, 66, 10.8f, 1, 2024 },
                    { 262, 66, -0.7f, 2, 2024 },
                    { 263, 66, 6.2f, 3, 2024 },
                    { 264, 66, 15.1f, 4, 2024 },
                    { 265, 67, 8.3f, 1, 2024 },
                    { 266, 67, 7f, 2, 2024 },
                    { 267, 67, 19.2f, 3, 2024 },
                    { 268, 67, 15.3f, 4, 2024 },
                    { 269, 68, -3f, 1, 2024 },
                    { 270, 68, 15f, 2, 2024 },
                    { 271, 68, 3f, 3, 2024 },
                    { 272, 68, 6.5f, 4, 2024 },
                    { 273, 69, 17.1f, 1, 2024 },
                    { 274, 69, -4.9f, 2, 2024 },
                    { 275, 69, 8f, 3, 2024 },
                    { 276, 69, 17f, 4, 2024 },
                    { 277, 70, 10.5f, 1, 2024 },
                    { 278, 70, 12.4f, 2, 2024 },
                    { 279, 70, 14.4f, 3, 2024 },
                    { 280, 70, 9.9f, 4, 2024 },
                    { 281, 71, 4f, 1, 2024 },
                    { 282, 71, 0.5f, 2, 2024 },
                    { 283, 71, 9.7f, 3, 2024 },
                    { 284, 71, 10.8f, 4, 2024 },
                    { 285, 72, 10.9f, 1, 2024 },
                    { 286, 72, -3.2f, 2, 2024 },
                    { 287, 72, -3.7f, 3, 2024 },
                    { 288, 72, 19.5f, 4, 2024 },
                    { 289, 73, 14.1f, 1, 2024 },
                    { 290, 73, 9.3f, 2, 2024 },
                    { 291, 73, 1.1f, 3, 2024 },
                    { 292, 73, 10.7f, 4, 2024 },
                    { 293, 74, 3.8f, 1, 2024 },
                    { 294, 74, 17.5f, 2, 2024 },
                    { 295, 74, 15.5f, 3, 2024 },
                    { 296, 74, 5.1f, 4, 2024 },
                    { 297, 75, 4.4f, 1, 2024 },
                    { 298, 75, -1.7f, 2, 2024 },
                    { 299, 75, 7.3f, 3, 2024 },
                    { 300, 75, 16f, 4, 2024 },
                    { 301, 76, 10.3f, 1, 2024 },
                    { 302, 76, -1.3f, 2, 2024 },
                    { 303, 76, 16.8f, 3, 2024 },
                    { 304, 76, 4.6f, 4, 2024 },
                    { 305, 77, -0.6f, 1, 2024 },
                    { 306, 77, 4.5f, 2, 2024 },
                    { 307, 77, 19.7f, 3, 2024 },
                    { 308, 77, 17.7f, 4, 2024 },
                    { 309, 78, 18.9f, 1, 2024 },
                    { 310, 78, 19.2f, 2, 2024 },
                    { 311, 78, 4.1f, 3, 2024 },
                    { 312, 78, 5.4f, 4, 2024 },
                    { 313, 79, 12f, 1, 2024 },
                    { 314, 79, 18.9f, 2, 2024 },
                    { 315, 79, 12.3f, 3, 2024 },
                    { 316, 79, 0.3f, 4, 2024 },
                    { 317, 80, -2.2f, 1, 2024 },
                    { 318, 80, -1.2f, 2, 2024 },
                    { 319, 80, 15.9f, 3, 2024 },
                    { 320, 80, 14f, 4, 2024 },
                    { 321, 81, 19.9f, 1, 2024 },
                    { 322, 81, -5f, 2, 2024 },
                    { 323, 81, 13.5f, 3, 2024 },
                    { 324, 81, 0.8f, 4, 2024 },
                    { 325, 82, 8f, 1, 2024 },
                    { 326, 82, 1.1f, 2, 2024 },
                    { 327, 82, 10.3f, 3, 2024 },
                    { 328, 82, 3.6f, 4, 2024 },
                    { 329, 83, 19.7f, 1, 2024 },
                    { 330, 83, 2.8f, 2, 2024 },
                    { 331, 83, 13.7f, 3, 2024 },
                    { 332, 83, 15.5f, 4, 2024 },
                    { 333, 84, -3.8f, 1, 2024 },
                    { 334, 84, 11.9f, 2, 2024 },
                    { 335, 84, 1.2f, 3, 2024 },
                    { 336, 84, -4.8f, 4, 2024 },
                    { 337, 85, 5.9f, 1, 2024 },
                    { 338, 85, 15.9f, 2, 2024 },
                    { 339, 85, 15.9f, 3, 2024 },
                    { 340, 85, 18.1f, 4, 2024 },
                    { 341, 86, 17.2f, 1, 2024 },
                    { 342, 86, 11.8f, 2, 2024 },
                    { 343, 86, 4.2f, 3, 2024 },
                    { 344, 86, 12.9f, 4, 2024 },
                    { 345, 87, 11.6f, 1, 2024 },
                    { 346, 87, 15.3f, 2, 2024 },
                    { 347, 87, 14.9f, 3, 2024 },
                    { 348, 87, 3.8f, 4, 2024 },
                    { 349, 88, 7.2f, 1, 2024 },
                    { 350, 88, 11.3f, 2, 2024 },
                    { 351, 88, 14.3f, 3, 2024 },
                    { 352, 88, 18.7f, 4, 2024 },
                    { 353, 89, -4.9f, 1, 2024 },
                    { 354, 89, 4.3f, 2, 2024 },
                    { 355, 89, -1.7f, 3, 2024 },
                    { 356, 89, -4.2f, 4, 2024 },
                    { 357, 90, 1.8f, 1, 2024 },
                    { 358, 90, 3f, 2, 2024 },
                    { 359, 90, 13f, 3, 2024 },
                    { 360, 90, 11.3f, 4, 2024 },
                    { 361, 91, 11.5f, 1, 2024 },
                    { 362, 91, 1f, 2, 2024 },
                    { 363, 91, 18.1f, 3, 2024 },
                    { 364, 91, 15.8f, 4, 2024 },
                    { 365, 92, 7.7f, 1, 2024 },
                    { 366, 92, 6.9f, 2, 2024 },
                    { 367, 92, 11.7f, 3, 2024 },
                    { 368, 92, -2.6f, 4, 2024 },
                    { 369, 93, 5.1f, 1, 2024 },
                    { 370, 93, 13.9f, 2, 2024 },
                    { 371, 93, 14.3f, 3, 2024 },
                    { 372, 93, 11.7f, 4, 2024 },
                    { 373, 94, 15.8f, 1, 2024 },
                    { 374, 94, -5f, 2, 2024 },
                    { 375, 94, 14.3f, 3, 2024 },
                    { 376, 94, 14.4f, 4, 2024 },
                    { 377, 95, 10.7f, 1, 2024 },
                    { 378, 95, -2.6f, 2, 2024 },
                    { 379, 95, 2.4f, 3, 2024 },
                    { 380, 95, 14.8f, 4, 2024 },
                    { 381, 96, 18.2f, 1, 2024 },
                    { 382, 96, 17.7f, 2, 2024 },
                    { 383, 96, 13.7f, 3, 2024 },
                    { 384, 96, 3.6f, 4, 2024 },
                    { 385, 97, 10.6f, 1, 2024 },
                    { 386, 97, 13.3f, 2, 2024 },
                    { 387, 97, 5.6f, 3, 2024 },
                    { 388, 97, 18f, 4, 2024 },
                    { 389, 98, 6.6f, 1, 2024 },
                    { 390, 98, 17.1f, 2, 2024 },
                    { 391, 98, -3.9f, 3, 2024 },
                    { 392, 98, -2.8f, 4, 2024 },
                    { 393, 99, -0.3f, 1, 2024 },
                    { 394, 99, 16.8f, 2, 2024 },
                    { 395, 99, -4.8f, 3, 2024 },
                    { 396, 99, 9.6f, 4, 2024 },
                    { 397, 100, 13.4f, 1, 2024 },
                    { 398, 100, 8.3f, 2, 2024 },
                    { 399, 100, -0.1f, 3, 2024 },
                    { 400, 100, -4.1f, 4, 2024 },
                    { 401, 101, -3.8f, 1, 2024 },
                    { 402, 101, -2.8f, 2, 2024 },
                    { 403, 101, 4.3f, 3, 2024 },
                    { 404, 101, 7.5f, 4, 2024 },
                    { 405, 102, 16f, 1, 2024 },
                    { 406, 102, 2.8f, 2, 2024 },
                    { 407, 102, 10.6f, 3, 2024 },
                    { 408, 102, 8.2f, 4, 2024 },
                    { 409, 103, 18.7f, 1, 2024 },
                    { 410, 103, 7.5f, 2, 2024 },
                    { 411, 103, -1.2f, 3, 2024 },
                    { 412, 103, 3.6f, 4, 2024 },
                    { 413, 104, 19.6f, 1, 2024 },
                    { 414, 104, -1.8f, 2, 2024 },
                    { 415, 104, 4.3f, 3, 2024 },
                    { 416, 104, 16.9f, 4, 2024 },
                    { 417, 105, -2.2f, 1, 2024 },
                    { 418, 105, 11.4f, 2, 2024 },
                    { 419, 105, 14.6f, 3, 2024 },
                    { 420, 105, 15.4f, 4, 2024 },
                    { 421, 106, 4.3f, 1, 2024 },
                    { 422, 106, -2.5f, 2, 2024 },
                    { 423, 106, 13.8f, 3, 2024 },
                    { 424, 106, 0.4f, 4, 2024 },
                    { 425, 107, 13.5f, 1, 2024 },
                    { 426, 107, 7.7f, 2, 2024 },
                    { 427, 107, 2.7f, 3, 2024 },
                    { 428, 107, 5f, 4, 2024 },
                    { 429, 108, 0.9f, 1, 2024 },
                    { 430, 108, 1.8f, 2, 2024 },
                    { 431, 108, 8.8f, 3, 2024 },
                    { 432, 108, 15.8f, 4, 2024 },
                    { 433, 109, -1.6f, 1, 2024 },
                    { 434, 109, 2.4f, 2, 2024 },
                    { 435, 109, 15.7f, 3, 2024 },
                    { 436, 109, -4.3f, 4, 2024 },
                    { 437, 110, 13.2f, 1, 2024 },
                    { 438, 110, 15.7f, 2, 2024 },
                    { 439, 110, 13.9f, 3, 2024 },
                    { 440, 110, 18.2f, 4, 2024 },
                    { 441, 111, 5.8f, 1, 2024 },
                    { 442, 111, 16.8f, 2, 2024 },
                    { 443, 111, 9.5f, 3, 2024 },
                    { 444, 111, 0.5f, 4, 2024 },
                    { 445, 112, 16.8f, 1, 2024 },
                    { 446, 112, 8.1f, 2, 2024 },
                    { 447, 112, 5.7f, 3, 2024 },
                    { 448, 112, 0.9f, 4, 2024 },
                    { 449, 113, 6.6f, 1, 2024 },
                    { 450, 113, 4.8f, 2, 2024 },
                    { 451, 113, -3.8f, 3, 2024 },
                    { 452, 113, 18.7f, 4, 2024 },
                    { 453, 114, -1.3f, 1, 2024 },
                    { 454, 114, 0.3f, 2, 2024 },
                    { 455, 114, 2.9f, 3, 2024 },
                    { 456, 114, 1.9f, 4, 2024 },
                    { 457, 115, 18.7f, 1, 2024 },
                    { 458, 115, 4.7f, 2, 2024 },
                    { 459, 115, 16.5f, 3, 2024 },
                    { 460, 115, 8.1f, 4, 2024 },
                    { 461, 116, 4f, 1, 2024 },
                    { 462, 116, -1.6f, 2, 2024 },
                    { 463, 116, 10.5f, 3, 2024 },
                    { 464, 116, 18.6f, 4, 2024 },
                    { 465, 117, 16.3f, 1, 2024 },
                    { 466, 117, 3.5f, 2, 2024 },
                    { 467, 117, 0.9f, 3, 2024 },
                    { 468, 117, -3.4f, 4, 2024 },
                    { 469, 118, 19.4f, 1, 2024 },
                    { 470, 118, 13.6f, 2, 2024 },
                    { 471, 118, 19.6f, 3, 2024 },
                    { 472, 118, 12.9f, 4, 2024 },
                    { 473, 119, 9.2f, 1, 2024 },
                    { 474, 119, 19.8f, 2, 2024 },
                    { 475, 119, 3.2f, 3, 2024 },
                    { 476, 119, -2.2f, 4, 2024 },
                    { 477, 120, 10.6f, 1, 2024 },
                    { 478, 120, 10.6f, 2, 2024 },
                    { 479, 120, 6.3f, 3, 2024 },
                    { 480, 120, -4.1f, 4, 2024 },
                    { 481, 121, -3f, 1, 2024 },
                    { 482, 121, 1.8f, 2, 2024 },
                    { 483, 121, 19.8f, 3, 2024 },
                    { 484, 121, 15.8f, 4, 2024 },
                    { 485, 122, 9.5f, 1, 2024 },
                    { 486, 122, 4.3f, 2, 2024 },
                    { 487, 122, -2.7f, 3, 2024 },
                    { 488, 122, 8.7f, 4, 2024 },
                    { 489, 123, -4.6f, 1, 2024 },
                    { 490, 123, 15f, 2, 2024 },
                    { 491, 123, 14f, 3, 2024 },
                    { 492, 123, 9.2f, 4, 2024 },
                    { 493, 124, 8.2f, 1, 2024 },
                    { 494, 124, 2.1f, 2, 2024 },
                    { 495, 124, 5.6f, 3, 2024 },
                    { 496, 124, 16f, 4, 2024 },
                    { 497, 125, 13.9f, 1, 2024 },
                    { 498, 125, 15.9f, 2, 2024 },
                    { 499, 125, -0.4f, 3, 2024 },
                    { 500, 125, 8.2f, 4, 2024 },
                    { 501, 126, -0.8f, 1, 2024 },
                    { 502, 126, -2f, 2, 2024 },
                    { 503, 126, -4.5f, 3, 2024 },
                    { 504, 126, 1.7f, 4, 2024 },
                    { 505, 127, 20f, 1, 2024 },
                    { 506, 127, 4f, 2, 2024 },
                    { 507, 127, -1.6f, 3, 2024 },
                    { 508, 127, -1f, 4, 2024 },
                    { 509, 128, 3.9f, 1, 2024 },
                    { 510, 128, 5f, 2, 2024 },
                    { 511, 128, -3.4f, 3, 2024 },
                    { 512, 128, 0f, 4, 2024 },
                    { 513, 129, -5f, 1, 2024 },
                    { 514, 129, 3.8f, 2, 2024 },
                    { 515, 129, 18.8f, 3, 2024 },
                    { 516, 129, 7.7f, 4, 2024 },
                    { 517, 130, 11.1f, 1, 2024 },
                    { 518, 130, 2.8f, 2, 2024 },
                    { 519, 130, 8.6f, 3, 2024 },
                    { 520, 130, 19.7f, 4, 2024 },
                    { 521, 131, 3f, 1, 2024 },
                    { 522, 131, 9.4f, 2, 2024 },
                    { 523, 131, 4.8f, 3, 2024 },
                    { 524, 131, 15.5f, 4, 2024 },
                    { 525, 132, 11.9f, 1, 2024 },
                    { 526, 132, 9.2f, 2, 2024 },
                    { 527, 132, 12.5f, 3, 2024 },
                    { 528, 132, 6f, 4, 2024 },
                    { 529, 133, 10.7f, 1, 2024 },
                    { 530, 133, 14.9f, 2, 2024 },
                    { 531, 133, 14.2f, 3, 2024 },
                    { 532, 133, 15.7f, 4, 2024 },
                    { 533, 134, 10f, 1, 2024 },
                    { 534, 134, 0.8f, 2, 2024 },
                    { 535, 134, 5.6f, 3, 2024 },
                    { 536, 134, 10.8f, 4, 2024 },
                    { 537, 135, 11.6f, 1, 2024 },
                    { 538, 135, -4.8f, 2, 2024 },
                    { 539, 135, 5.3f, 3, 2024 },
                    { 540, 135, 2.2f, 4, 2024 },
                    { 541, 136, 12.7f, 1, 2024 },
                    { 542, 136, -2f, 2, 2024 },
                    { 543, 136, 15.4f, 3, 2024 },
                    { 544, 136, 14.8f, 4, 2024 },
                    { 545, 137, 12.9f, 1, 2024 },
                    { 546, 137, 18.4f, 2, 2024 },
                    { 547, 137, -4.6f, 3, 2024 },
                    { 548, 137, 12.1f, 4, 2024 },
                    { 549, 138, 6.1f, 1, 2024 },
                    { 550, 138, -1.4f, 2, 2024 },
                    { 551, 138, -1.4f, 3, 2024 },
                    { 552, 138, 9.9f, 4, 2024 },
                    { 553, 139, 7.6f, 1, 2024 },
                    { 554, 139, 7f, 2, 2024 },
                    { 555, 139, 0.8f, 3, 2024 },
                    { 556, 139, 13.6f, 4, 2024 },
                    { 557, 140, 8.2f, 1, 2024 },
                    { 558, 140, 18.9f, 2, 2024 },
                    { 559, 140, 11.8f, 3, 2024 },
                    { 560, 140, 11.2f, 4, 2024 },
                    { 561, 141, 11.8f, 1, 2024 },
                    { 562, 141, -2.5f, 2, 2024 },
                    { 563, 141, 5f, 3, 2024 },
                    { 564, 141, 11.9f, 4, 2024 },
                    { 565, 142, 11.8f, 1, 2024 },
                    { 566, 142, 11.9f, 2, 2024 },
                    { 567, 142, 9.7f, 3, 2024 },
                    { 568, 142, 9.8f, 4, 2024 },
                    { 569, 143, -4.3f, 1, 2024 },
                    { 570, 143, 4.4f, 2, 2024 },
                    { 571, 143, 11.1f, 3, 2024 },
                    { 572, 143, 6.6f, 4, 2024 },
                    { 573, 144, 14.1f, 1, 2024 },
                    { 574, 144, 13.2f, 2, 2024 },
                    { 575, 144, 14.3f, 3, 2024 },
                    { 576, 144, -4f, 4, 2024 },
                    { 577, 145, 7.7f, 1, 2024 },
                    { 578, 145, 8f, 2, 2024 },
                    { 579, 145, 4f, 3, 2024 },
                    { 580, 145, -4.4f, 4, 2024 },
                    { 581, 146, 17.9f, 1, 2024 },
                    { 582, 146, -2.5f, 2, 2024 },
                    { 583, 146, 16.9f, 3, 2024 },
                    { 584, 146, 5.8f, 4, 2024 },
                    { 585, 147, 6.2f, 1, 2024 },
                    { 586, 147, -4.6f, 2, 2024 },
                    { 587, 147, 11.9f, 3, 2024 },
                    { 588, 147, 0.9f, 4, 2024 },
                    { 589, 148, 18.9f, 1, 2024 },
                    { 590, 148, -3.7f, 2, 2024 },
                    { 591, 148, 12.5f, 3, 2024 },
                    { 592, 148, -2.3f, 4, 2024 },
                    { 593, 149, 18.6f, 1, 2024 },
                    { 594, 149, -4.4f, 2, 2024 },
                    { 595, 149, 5f, 3, 2024 },
                    { 596, 149, 2.6f, 4, 2024 },
                    { 597, 150, 9.5f, 1, 2024 },
                    { 598, 150, 5.9f, 2, 2024 },
                    { 599, 150, 11.5f, 3, 2024 },
                    { 600, 150, 8.6f, 4, 2024 },
                    { 601, 151, 6.8f, 1, 2024 },
                    { 602, 151, 11.5f, 2, 2024 },
                    { 603, 151, 19.9f, 3, 2024 },
                    { 604, 151, 16.4f, 4, 2024 },
                    { 605, 152, 7.8f, 1, 2024 },
                    { 606, 152, -2.8f, 2, 2024 },
                    { 607, 152, 16.8f, 3, 2024 },
                    { 608, 152, 2.3f, 4, 2024 },
                    { 609, 153, -1.6f, 1, 2024 },
                    { 610, 153, 19.5f, 2, 2024 },
                    { 611, 153, -1.7f, 3, 2024 },
                    { 612, 153, 6.8f, 4, 2024 },
                    { 613, 154, 2.3f, 1, 2024 },
                    { 614, 154, 12.4f, 2, 2024 },
                    { 615, 154, -4.7f, 3, 2024 },
                    { 616, 154, 15.2f, 4, 2024 },
                    { 617, 155, -2.5f, 1, 2024 },
                    { 618, 155, 11.7f, 2, 2024 },
                    { 619, 155, -0.9f, 3, 2024 },
                    { 620, 155, 4.1f, 4, 2024 },
                    { 621, 156, 4.8f, 1, 2024 },
                    { 622, 156, 18.5f, 2, 2024 },
                    { 623, 156, 6.6f, 3, 2024 },
                    { 624, 156, 9.2f, 4, 2024 },
                    { 625, 157, 5.2f, 1, 2024 },
                    { 626, 157, 17f, 2, 2024 },
                    { 627, 157, 6.2f, 3, 2024 },
                    { 628, 157, 7.3f, 4, 2024 },
                    { 629, 158, 13.8f, 1, 2024 },
                    { 630, 158, 1.9f, 2, 2024 },
                    { 631, 158, 17.5f, 3, 2024 },
                    { 632, 158, 7.9f, 4, 2024 },
                    { 633, 159, 11.9f, 1, 2024 },
                    { 634, 159, 11.3f, 2, 2024 },
                    { 635, 159, -4.6f, 3, 2024 },
                    { 636, 159, -4.2f, 4, 2024 },
                    { 637, 160, -5f, 1, 2024 },
                    { 638, 160, 11f, 2, 2024 },
                    { 639, 160, 3.8f, 3, 2024 },
                    { 640, 160, 12.1f, 4, 2024 }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "SeasonId", "RealSeason", "SeasonStartDate", "SeasonYear" },
                values: new object[] { 1, false, new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 2025 });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "RequiresBackup", "StatusType", "ViableToPlay" },
                values: new object[,]
                {
                    { 1, false, "Green", true },
                    { 2, true, "IR", false },
                    { 3, true, "O", false },
                    { 4, true, "Q", true },
                    { 5, true, "D", true },
                    { 6, true, "SSPD", false }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "ByeWeek", "TeamCity", "TeamName" },
                values: new object[,]
                {
                    { 1, 0, "Denver", "Thunderbirds" },
                    { 2, 0, "Atlanta", "Vipers" },
                    { 3, 0, "Houston", "Ironhounds" },
                    { 4, 0, "Chicago", "Stallions" },
                    { 5, 0, "Seattle", "Warhawks" },
                    { 6, 0, "Orlando", "Cyclones" },
                    { 7, 0, "Nashville", "Guardians" },
                    { 8, 0, "Portland", "Lumberjacks" },
                    { 9, 0, "Las Vegas", "Outlaws" },
                    { 10, 0, "Kansas City", "Redtails" },
                    { 11, 0, "Phoenix", "Firestorm" },
                    { 12, 0, "Brooklyn", "Sentinels" },
                    { 13, 0, "Miami", "Hurricanes" },
                    { 14, 0, "San Diego", "Tritons" },
                    { 15, 0, "Detroit", "Phantoms" },
                    { 16, 0, "Carolina", "Cobras" },
                    { 17, 0, "New Jersey", "Rampage" },
                    { 18, 0, "St. Louis", "Renegades" },
                    { 19, 0, "Oklahoma City", "Mustangs" },
                    { 20, 0, "Cincinnati", "Scorpions" }
                });

            migrationBuilder.InsertData(
                table: "ActivePeriods",
                columns: new[] { "ActivePeriodId", "End", "Start", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 11, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 12, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 13, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 14, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 15, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 16, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 17, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 18, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 18 },
                    { 19, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 19 },
                    { 20, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 20 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "PlayerFirstName", "PlayerLastName", "PositionId", "StatusId" },
                values: new object[,]
                {
                    { 1, "Jake", "Mason", 1, 1 },
                    { 2, "Evan", "Carter", 1, 1 },
                    { 3, "Derek", "Henderson", 1, 1 },
                    { 4, "Marcus", "Wells", 1, 1 },
                    { 5, "Tyler", "Nash", 1, 1 },
                    { 6, "Brad", "McKinney", 1, 1 },
                    { 7, "Chris", "Johnson", 1, 1 },
                    { 8, "Brandon", "Richards", 1, 1 },
                    { 9, "Kyle", "Foster", 1, 1 },
                    { 10, "Matt", "Griffin", 1, 1 },
                    { 11, "Trevor", "Burns", 1, 1 },
                    { 12, "Grant", "Hunter", 1, 1 },
                    { 13, "Dylan", "Reed", 1, 1 },
                    { 14, "Nick", "Evans", 1, 1 },
                    { 15, "Scott", "Bailey", 1, 1 },
                    { 16, "Troy", "Farmer", 1, 1 },
                    { 17, "Zach", "Lowe", 1, 1 },
                    { 18, "Hunter", "Murphy", 1, 1 },
                    { 19, "Austin", "Patterson", 1, 1 },
                    { 20, "Caleb", "Harrison", 1, 1 },
                    { 21, "Ryan", "Fitzgerald", 4, 1 },
                    { 22, "Mason", "Scott", 4, 1 },
                    { 23, "Jordan", "Brooks", 4, 1 },
                    { 24, "Jason", "Douglas", 4, 1 },
                    { 25, "Alex", "Cooper", 4, 1 },
                    { 26, "Chase", "Garrett", 4, 1 },
                    { 27, "Cody", "Thompson", 4, 1 },
                    { 28, "Landon", "Pearson", 4, 1 },
                    { 29, "Jared", "Dunn", 4, 1 },
                    { 30, "Drew", "Cross", 4, 1 },
                    { 31, "Colin", "Shelby", 4, 1 },
                    { 32, "Garrett", "Coleman", 4, 1 },
                    { 33, "Bryce", "Fowler", 4, 1 },
                    { 34, "Clay", "Sanders", 4, 1 },
                    { 35, "Isaac", "McLean", 4, 1 },
                    { 36, "Cole", "Washington", 4, 1 },
                    { 37, "Blake", "Morris", 4, 1 },
                    { 38, "Nate", "Bryant", 4, 1 },
                    { 39, "Jesse", "Holmes", 4, 1 },
                    { 40, "Connor", "Davis", 4, 1 },
                    { 41, "Lucas", "Smith", 5, 1 },
                    { 42, "Noah", "Johnson", 5, 1 },
                    { 43, "Ethan", "Williams", 5, 1 },
                    { 44, "Logan", "Jones", 5, 1 },
                    { 45, "Mason", "Brown", 5, 1 },
                    { 46, "Oliver", "Davis", 5, 1 },
                    { 47, "Liam", "Miller", 5, 1 },
                    { 48, "Jacob", "Wilson", 5, 1 },
                    { 49, "James", "Moore", 5, 1 },
                    { 50, "Benjamin", "Taylor", 5, 1 },
                    { 51, "Henry", "Anderson", 5, 1 },
                    { 52, "Owen", "Thomas", 5, 1 },
                    { 53, "William", "Jackson", 5, 1 },
                    { 54, "Elijah", "White", 5, 1 },
                    { 55, "Jackson", "Harris", 5, 1 },
                    { 56, "Gabriel", "Clark", 5, 1 },
                    { 57, "Sebastian", "Rodriguez", 5, 1 },
                    { 58, "Daniel", "Lewis", 5, 1 },
                    { 59, "Nathan", "Walker", 5, 1 },
                    { 60, "Ethan", "Adams", 5, 1 },
                    { 61, "Aiden", "Miller", 2, 1 },
                    { 62, "Liam", "Brown", 2, 1 },
                    { 63, "Alexander", "Jones", 2, 1 },
                    { 64, "Joseph", "Garcia", 2, 1 },
                    { 65, "Samuel", "Martinez", 2, 1 },
                    { 66, "Matthew", "Hernandez", 2, 1 },
                    { 67, "David", "Lopez", 2, 1 },
                    { 68, "Andrew", "Gonzalez", 2, 1 },
                    { 69, "Joshua", "Wilson", 2, 1 },
                    { 70, "Christopher", "Perez", 2, 1 },
                    { 71, "Thomas", "Taylor", 2, 1 },
                    { 72, "John", "Anderson", 2, 1 },
                    { 73, "James", "Thomas", 2, 1 },
                    { 74, "Brian", "Jackson", 2, 1 },
                    { 75, "Nicholas", "White", 2, 1 },
                    { 76, "Justin", "Harris", 2, 1 },
                    { 77, "Aaron", "Clark", 2, 1 },
                    { 78, "Zachary", "Lewis", 2, 1 },
                    { 79, "Paul", "Walker", 2, 1 },
                    { 80, "Eric", "Young", 2, 1 },
                    { 81, "Sean", "King", 2, 1 },
                    { 82, "Ray", "Scott", 2, 1 },
                    { 83, "Derek", "Adams", 2, 1 },
                    { 84, "Kevin", "Baker", 2, 1 },
                    { 85, "Tony", "Collins", 2, 1 },
                    { 86, "Cameron", "Cox", 2, 1 },
                    { 87, "Adam", "Stewart", 2, 1 },
                    { 88, "Kyle", "Turner", 2, 1 },
                    { 89, "Greg", "Hughes", 2, 1 },
                    { 90, "Mike", "Ramirez", 2, 1 },
                    { 91, "Patrick", "Ross", 2, 1 },
                    { 92, "Alex", "Powell", 2, 1 },
                    { 93, "Steven", "Griffin", 2, 1 },
                    { 94, "Bill", "Brooks", 2, 1 },
                    { 95, "Daniel", "Kelly", 2, 1 },
                    { 96, "Rob", "Foster", 2, 1 },
                    { 97, "Jeff", "Reed", 2, 1 },
                    { 98, "Phil", "Patterson", 2, 1 },
                    { 99, "Larry", "Burns", 2, 1 },
                    { 100, "Jackson", "Wilson", 2, 1 },
                    { 101, "Owen", "Taylor", 3, 1 },
                    { 102, "Logan", "Lee", 3, 1 },
                    { 103, "Dylan", "Perez", 3, 1 },
                    { 104, "Aiden", "Gonzalez", 3, 1 },
                    { 105, "Elijah", "Mitchell", 3, 1 },
                    { 106, "Henry", "Carter", 3, 1 },
                    { 107, "Ethan", "Torres", 3, 1 },
                    { 108, "Alexander", "Evans", 3, 1 },
                    { 109, "Logan", "Edwards", 3, 1 },
                    { 110, "Jackson", "Collins", 3, 1 },
                    { 111, "Landon", "Morris", 3, 1 },
                    { 112, "Bryson", "Murphy", 3, 1 },
                    { 113, "Parker", "Powell", 3, 1 },
                    { 114, "Jameson", "Sullivan", 3, 1 },
                    { 115, "Bentley", "Bryant", 3, 1 },
                    { 116, "Carson", "Newton", 3, 1 },
                    { 117, "Braxton", "Lambert", 3, 1 },
                    { 118, "Tucker", "Cruz", 3, 1 },
                    { 119, "Zane", "Owen", 3, 1 },
                    { 120, "Rowan", "Knight", 3, 1 },
                    { 121, "Harrison", "Lane", 3, 1 },
                    { 122, "Weston", "Hicks", 3, 1 },
                    { 123, "Finley", "Abbott", 3, 1 },
                    { 124, "Sullivan", "Reeves", 3, 1 },
                    { 125, "Reid", "Jenkins", 3, 1 },
                    { 126, "Archer", "Gibson", 3, 1 },
                    { 127, "Rhys", "Parks", 3, 1 },
                    { 128, "Knox", "Greene", 3, 1 },
                    { 129, "Brody", "Austin", 3, 1 },
                    { 130, "Cade", "Wells", 3, 1 },
                    { 131, "Theo", "Wagner", 3, 1 },
                    { 132, "Sterling", "Rice", 3, 1 },
                    { 133, "Jude", "Hayes", 3, 1 },
                    { 134, "Crosby", "Houston", 3, 1 },
                    { 135, "Porter", "Hale", 3, 1 },
                    { 136, "Beckham", "Wallace", 3, 1 },
                    { 137, "Judah", "Leonard", 3, 1 },
                    { 138, "Griffin", "Todd", 3, 1 },
                    { 139, "Phoenix", "Webb", 3, 1 },
                    { 140, "Dawson", "Sanders", 3, 1 },
                    { 141, "Denver", "Thunderbirds", 6, 1 },
                    { 142, "Atlanta", "Vipers", 6, 1 },
                    { 143, "Houston", "Ironhounds", 6, 1 },
                    { 144, "Chicago", "Stallions", 6, 1 },
                    { 145, "Seattle", "Warhawks", 6, 1 },
                    { 146, "Orlando", "Cyclones", 6, 1 },
                    { 147, "Nashville", "Guardians", 6, 1 },
                    { 148, "Portland", "Lumberjacks", 6, 1 },
                    { 149, "Las Vegas", "Outlaws", 6, 1 },
                    { 150, "Kansas City", "Redtails", 6, 1 },
                    { 151, "Phoenix", "Firestorm", 6, 1 },
                    { 152, "Brooklyn", "Sentinels", 6, 1 },
                    { 153, "Miami", "Hurricanes", 6, 1 },
                    { 154, "San Diego", "Tritons", 6, 1 },
                    { 155, "Detroit", "Phantoms", 6, 1 },
                    { 156, "Carolina", "Cobras", 6, 1 },
                    { 157, "New Jersey", "Rampage", 6, 1 },
                    { 158, "St. Louis", "Renegades", 6, 1 },
                    { 159, "Oklahoma City", "Mustangs", 6, 1 },
                    { 160, "Cincinnati", "Scorpions", 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "IdentityUserId" },
                values: new object[] { 1, "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "LeagueUsers",
                columns: new[] { "LeagueUserId", "LeagueId", "RosterId", "UserProfileId" },
                values: new object[] { 1, 1, 1, 1 });

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

            migrationBuilder.CreateIndex(
                name: "IX_ActivePeriods_TeamId",
                table: "ActivePeriods",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeagueUsers_LeagueId",
                table: "LeagueUsers",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueUsers_RosterId",
                table: "LeagueUsers",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueUsers_UserProfileId",
                table: "LeagueUsers",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupUsers_MatchupId",
                table: "MatchupUsers",
                column: "MatchupId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupUsers_UserProfileId",
                table: "MatchupUsers",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_StatusId",
                table: "Players",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RosterPlayers_PlayerId",
                table: "RosterPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RosterPlayers_RosterId",
                table: "RosterPlayers",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivePeriods");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LeagueUsers");

            migrationBuilder.DropTable(
                name: "MatchupUsers");

            migrationBuilder.DropTable(
                name: "RosterPlayers");

            migrationBuilder.DropTable(
                name: "Scorings");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Matchups");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rosters");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
