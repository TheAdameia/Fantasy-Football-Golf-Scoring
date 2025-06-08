using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddTradeAndTradePlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonWeeks",
                table: "Seasons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    TradeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeagueId = table.Column<int>(type: "integer", nullable: false),
                    FirstPartyRosterId = table.Column<int>(type: "integer", nullable: false),
                    SecondPartyRosterId = table.Column<int>(type: "integer", nullable: false),
                    WeekActivation = table.Column<int>(type: "integer", nullable: false),
                    FirstPartyAcceptance = table.Column<bool>(type: "boolean", nullable: false),
                    SecondPartyAcceptance = table.Column<bool>(type: "boolean", nullable: false),
                    TradeComplete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.TradeId);
                });

            migrationBuilder.CreateTable(
                name: "TradePlayers",
                columns: table => new
                {
                    TradePlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TradeId = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    GivingRosterId = table.Column<int>(type: "integer", nullable: false),
                    ReceivingRosterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradePlayers", x => x.TradePlayerId);
                    table.ForeignKey(
                        name: "FK_TradePlayers_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "TradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca35ccea-97a3-4e49-9d81-f28fbe996cb4", "AQAAAAIAAYagAAAAEJTdg9JncwjTp5ZIQuo5DMGt84U6qlLBe3o/+zLQC3nZVPktQHFKJMeIIttS+sMHPg==", "72391bd2-c5a3-4160-91e6-72fa963a19f4" });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "SeasonId",
                keyValue: 1,
                column: "SeasonWeeks",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "StatusType",
                value: "Healthy");

            migrationBuilder.CreateIndex(
                name: "IX_TradePlayers_TradeId",
                table: "TradePlayers",
                column: "TradeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradePlayers");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropColumn(
                name: "SeasonWeeks",
                table: "Seasons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9476c0c-3a81-4432-872b-b65121dee51a", "AQAAAAIAAYagAAAAEHPcL/VAO/VxcQnnOsuP1UfKSrbmSlY8WhcCCh9pvJ2NM2aoi9rKpmkyAlVd+slOwQ==", "f357d0a9-5aa9-4ba4-b7d8-54ac0e49a69a" });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "StatusType",
                value: "Green");
        }
    }
}
