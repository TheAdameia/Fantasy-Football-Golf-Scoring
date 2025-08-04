using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class RemoveActivePeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivePeriods");

            migrationBuilder.AddColumn<int>(
                name: "ExtraPointAttempts",
                table: "NewScoringTests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExtraPointMade",
                table: "NewScoringTests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouchdownsReceiving",
                table: "NewScoringTests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YardsReceiving",
                table: "NewScoringTests",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ef82674-d8ef-413d-acfb-3d562f2640a8", "AQAAAAIAAYagAAAAEEx8Xc09TkFDUB0zA/9Mzc3jjYxOI26VCqFSUp3/a2BoieO0tcUz1ecOkGvJaJFUnw==", "a47ec24c-9902-4c7f-9c16-78045e6be870" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraPointAttempts",
                table: "NewScoringTests");

            migrationBuilder.DropColumn(
                name: "ExtraPointMade",
                table: "NewScoringTests");

            migrationBuilder.DropColumn(
                name: "TouchdownsReceiving",
                table: "NewScoringTests");

            migrationBuilder.DropColumn(
                name: "YardsReceiving",
                table: "NewScoringTests");

            migrationBuilder.CreateTable(
                name: "ActivePeriods",
                columns: table => new
                {
                    ActivePeriodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.InsertData(
                table: "ActivePeriods",
                columns: new[] { "ActivePeriodId", "End", "Start", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 3, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 4, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 5, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 6, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 7, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 8, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 9, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 9 },
                    { 10, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 10 },
                    { 11, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 11 },
                    { 12, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 12 },
                    { 13, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 13 },
                    { 14, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 14 },
                    { 15, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 15 },
                    { 16, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 16 },
                    { 17, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 17 },
                    { 18, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 18 },
                    { 19, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 19 },
                    { 20, new DateTime(2040, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 3, 14, 8, 0, 0, 0, DateTimeKind.Utc), 20 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e46d40e4-2ec2-44cc-81cd-5f4eca5ea181", "AQAAAAIAAYagAAAAEAK6m6l9SgnW+n3ADj6R7eGCEaJ/szwcLeNWUL13FKtny35yId+fFOckOQP38/M8vw==", "49d98f82-05a5-4ce0-a98e-c64cc8a8bddb" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivePeriods_TeamId",
                table: "ActivePeriods",
                column: "TeamId");
        }
    }
}
