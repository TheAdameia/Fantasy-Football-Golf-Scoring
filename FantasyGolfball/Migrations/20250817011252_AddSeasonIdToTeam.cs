using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddSeasonIdToTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5082237-aaf3-43aa-b688-691ba5a90eb4", "AQAAAAIAAYagAAAAENvGeObYCOcr9aIKr8XGDMWOrr/7QzdalTG52FvyZcIAeUONNFwcAL/JbE8LnvOYBw==", "534c0cdf-bf95-4ece-8916-fa0d61265c59" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 5,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 6,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 7,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 8,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 9,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 10,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 11,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 12,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 13,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 14,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 15,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 16,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 17,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 18,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 19,
                column: "SeasonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 20,
                column: "SeasonId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Teams");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ef82674-d8ef-413d-acfb-3d562f2640a8", "AQAAAAIAAYagAAAAEEx8Xc09TkFDUB0zA/9Mzc3jjYxOI26VCqFSUp3/a2BoieO0tcUz1ecOkGvJaJFUnw==", "a47ec24c-9902-4c7f-9c16-78045e6be870" });
        }
    }
}
