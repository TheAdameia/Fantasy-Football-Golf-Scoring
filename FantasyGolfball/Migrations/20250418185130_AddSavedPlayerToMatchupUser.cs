using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddSavedPlayerToMatchupUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RosterPositionPlayerIds",
                table: "MatchupUsers");

            migrationBuilder.CreateTable(
                name: "MatchupUserSavedPlayers",
                columns: table => new
                {
                    MatchupUserSavedPlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatchupUserId = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    ScoringId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchupUserSavedPlayers", x => x.MatchupUserSavedPlayerId);
                    table.ForeignKey(
                        name: "FK_MatchupUserSavedPlayers_MatchupUsers_MatchupUserId",
                        column: x => x.MatchupUserId,
                        principalTable: "MatchupUsers",
                        principalColumn: "MatchupUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchupUserSavedPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchupUserSavedPlayers_Scorings_ScoringId",
                        column: x => x.ScoringId,
                        principalTable: "Scorings",
                        principalColumn: "ScoringId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73ff2965-7dc6-4bc2-bb86-4ebed6e29709", "AQAAAAIAAYagAAAAECDP8XSlWLSEash8h3SM0CSRespJ2X2FNyklnQZmog+c4etQemrUhfj/lo7UodpjJw==", "5527d4b2-f8ba-4ca4-938b-34cc7bd11387" });

            migrationBuilder.CreateIndex(
                name: "IX_MatchupUserSavedPlayers_MatchupUserId",
                table: "MatchupUserSavedPlayers",
                column: "MatchupUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupUserSavedPlayers_PlayerId",
                table: "MatchupUserSavedPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupUserSavedPlayers_ScoringId",
                table: "MatchupUserSavedPlayers",
                column: "ScoringId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchupUserSavedPlayers");

            migrationBuilder.AddColumn<Dictionary<string, List<int>>>(
                name: "RosterPositionPlayerIds",
                table: "MatchupUsers",
                type: "jsonb",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d19165c-b9c3-4058-b876-4e7838800d64", "AQAAAAIAAYagAAAAEJnvIWw0GUG4HmavwLF7rV2bcmft06+aAgqUDApDPQDfwxEvJiWWkc+OGPYAxuCi4g==", "07211996-be86-4432-99ab-557a08395536" });
        }
    }
}
