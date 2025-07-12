using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class fixTestsAddTeamAbbrv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "Teams",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlockedKicks",
                table: "NewScoringTests",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "NewPlayerTests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e46d40e4-2ec2-44cc-81cd-5f4eca5ea181", "AQAAAAIAAYagAAAAEAK6m6l9SgnW+n3ADj6R7eGCEaJ/szwcLeNWUL13FKtny35yId+fFOckOQP38/M8vw==", "49d98f82-05a5-4ce0-a98e-c64cc8a8bddb" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "RequiresBackup", "StatusType", "ViableToPlay" },
                values: new object[] { 7, true, "DNP", false });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 4,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 5,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 6,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 7,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 8,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 9,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 10,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 11,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 12,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 13,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 14,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 15,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 16,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 17,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 18,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 19,
                column: "Abbreviation",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 20,
                column: "Abbreviation",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "BlockedKicks",
                table: "NewScoringTests");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "NewPlayerTests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ad482bf-db5f-458e-acc7-9f627849b555", "AQAAAAIAAYagAAAAEEMCNS7pVGdKTlrLp56MHK/RG4L8ju+yJlu2Yt2sJ5uPllC4omVWT1AGJohyATXPMQ==", "1ef066fc-857e-4cde-8e65-44ab9e9ed98d" });
        }
    }
}
