using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddTouchdownsPassing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94d782af-e8aa-4e62-b711-5e12f912d375", "AQAAAAIAAYagAAAAEFjXTJowcn9z/27W+p7VlB2HeM6sN10Cq4u/laI6dk2xN+j+HA1mhTe9SVNFcAU1xA==", "cf683f32-adb4-40ce-be59-940e5fb01f2e" });

            migrationBuilder.AddColumn<int>(
                name: "TouchdownsPassing",
                table: "Scorings",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "744de316-039a-48ce-8f72-d42d1ebc9ce7", "AQAAAAIAAYagAAAAEJMRCwpzYAKX+ZgVBIBuJLXAHsqcBRnNDgPvrW60csai61Psp/2z+SJr+vfo4EFdag==", "9ac0fd13-1653-467f-b62e-444b94897dd5" });

            migrationBuilder.DropColumn(name: "TouchdownsPassing", table: "Scorings");
        }
    }
}
