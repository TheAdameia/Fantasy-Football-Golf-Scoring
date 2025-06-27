using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddSeasonWeeksToSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9e05b38-7ab5-4b4a-bf01-d46e0ecd88d2", "AQAAAAIAAYagAAAAEO2n/n1K3CyR11/VYM7M+84jRYKiJkP+Lz+1ezLGerxh7Aw1HeiMndkM/csVciZsMA==", "8651d3d8-50d8-49fd-934f-0b6015007cb1" });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "SeasonId",
                keyValue: 1,
                column: "SeasonWeeks",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
