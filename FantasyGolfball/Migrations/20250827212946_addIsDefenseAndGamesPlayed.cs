using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class addIsDefenseAndGamesPlayed : Migration
    {
        /// <inheritdoc />

        // this nightmare of migrations is why you never let your snapshot get out of sync with your migrations.
        // this should have been one migration. Ugh.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "744de316-039a-48ce-8f72-d42d1ebc9ce7", "AQAAAAIAAYagAAAAEJMRCwpzYAKX+ZgVBIBuJLXAHsqcBRnNDgPvrW60csai61Psp/2z+SJr+vfo4EFdag==", "9ac0fd13-1653-467f-b62e-444b94897dd5" });

            migrationBuilder.AddColumn<bool>(
                name: "IsDefense",
                table: "Scorings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d4ea61b-efeb-4783-9022-94eb1326e6fa", "AQAAAAIAAYagAAAAEBfrRjIXkfuDUbloFmLiP+b9FoU+HY4Rmu+01mOV9l15W6omcBRDh2xabIvOohakkw==", "b17ba705-1502-41c1-88ed-7f1873f545b4" });

            migrationBuilder.DropColumn(name: "IsDefense", table: "Scorings");
            migrationBuilder.DropColumn(name: "GamesPlayed", table: "Players");
        }
    }
}
