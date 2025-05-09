using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddHistoricalDraftState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricalDraftStates",
                columns: table => new
                {
                    HistoricalDraftStateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeagueId = table.Column<int>(type: "integer", nullable: false),
                    PermanentDraftOrderJson = table.Column<string>(type: "text", nullable: false),
                    UserRostersJson = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalDraftStates", x => x.HistoricalDraftStateId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9476c0c-3a81-4432-872b-b65121dee51a", "AQAAAAIAAYagAAAAEHPcL/VAO/VxcQnnOsuP1UfKSrbmSlY8WhcCCh9pvJ2NM2aoi9rKpmkyAlVd+slOwQ==", "f357d0a9-5aa9-4ba4-b7d8-54ac0e49a69a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricalDraftStates");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ed5ab02-c73a-45bd-b03f-aa98cf210a81", "AQAAAAIAAYagAAAAEFkq9m7E61k/L6p1shNat0BzLY9dMRLQYGTP1GCKHocXNAc9QsFE1HLsjr8j+Pmf6w==", "59f280a2-cb06-456b-86b0-15e3c94ef942" });
        }
    }
}
