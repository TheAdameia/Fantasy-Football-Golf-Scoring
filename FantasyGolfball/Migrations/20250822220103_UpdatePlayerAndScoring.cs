using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlayerAndScoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01d3a52c-42c3-43fb-94e8-0a5be8a5aac9", "AQAAAAIAAYagAAAAEGOBSSyxS+Mknu5TBcY9pKfZkxUgclpo8Nazuv7/2npbJp/bIwZjZkt+Ti1vkb9kHQ==", "75231040-4f28-4641-9987-5ac0337527f1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44909441-fa45-4728-b053-97dc8b1fd2d3", "AQAAAAIAAYagAAAAEBfr5eI8AecDdqFjiyYEmcQPheo9Nm79R3+bak6UR8/bj6B8B4Y2u4rV1bjSFftYEw==", "ee99772d-0bb3-405a-a0d2-3ffa4ae965dd" });
        }
    }
}
