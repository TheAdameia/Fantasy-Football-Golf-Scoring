using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddRequiresPasswordToLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequiresPassword",
                table: "Leagues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bade97b1-f77c-46ef-ad7e-21c1ad77f05d", "AQAAAAIAAYagAAAAEGQDOHlM98BcxzyFCIF8kVcbjizlTtEn4xxH0RFMrKxuDUTmveVqGEKquYo6xzPp/A==", "2734d54b-2a54-4597-a907-bb376b0842c8" });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 1,
                column: "RequiresPassword",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiresPassword",
                table: "Leagues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17ea9918-a758-4bbd-ad39-9491e77b1a57", "AQAAAAIAAYagAAAAEEp0Dz22WjeVb6s/PAJZwPvg9kkYzoEiqTaep0gq3pPBft/tfDXiwgvx9kKt9SlXLA==", "403c7224-ba62-45d8-b271-c01a11eea61f" });
        }
    }
}
