using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class RemovePointsFromScoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3429dea8-b847-44e8-8d68-a16a4786ee29", "AQAAAAIAAYagAAAAEI8VkZ9UMCcNKYTYkQDVkM6Bi/GJIiFJxIOBIhoLbm36xzWRdsFyOkpRzB4tLch4GA==", "e062b7d0-7e7a-44e5-bead-2c8b80d38b55" });

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Scorings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94d782af-e8aa-4e62-b711-5e12f912d375", "AQAAAAIAAYagAAAAEFjXTJowcn9z/27W+p7VlB2HeM6sN10Cq4u/laI6dk2xN+j+HA1mhTe9SVNFcAU1xA==", "cf683f32-adb4-40ce-be59-940e5fb01f2e" });

            migrationBuilder.AddColumn<float>(
                name: "Points",
                table: "Scorings",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
