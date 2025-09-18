using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class FixPlayerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d4ea61b-efeb-4783-9022-94eb1326e6fa", "AQAAAAIAAYagAAAAEBfrRjIXkfuDUbloFmLiP+b9FoU+HY4Rmu+01mOV9l15W6omcBRDh2xabIvOohakkw==", "b17ba705-1502-41c1-88ed-7f1873f545b4" });

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Players",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce9f8896-eccd-4301-b9a0-594582e05857", "AQAAAAIAAYagAAAAEFIo+qylTWwefmaVfaGpj5UuEjs4XBwxPAHn14/DzxCyUgZzl61jGu0AdaV1NpJrmg==", "12f9b09e-83bd-45ea-a293-0df8f2b87a4a" });

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Players");
        }
    }
}
