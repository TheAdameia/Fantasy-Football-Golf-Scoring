using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddLastRecordedWeekToSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastRecordedWeek",
                table: "Seasons",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "214cc153-57cc-4ecf-8ec4-d293234d31e0", "AQAAAAIAAYagAAAAEE1yhFL848capWgbeM6kz49os286JD0FM7z5L0I3UFo/oHyusDAief7IdWjv/bgIPA==", "0a3a26fa-c6c3-4d45-b7ab-4889abf0998f" });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "SeasonId",
                keyValue: 1,
                column: "LastRecordedWeek",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_SeasonId",
                table: "Leagues",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Seasons_SeasonId",
                table: "Leagues",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Seasons_SeasonId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_SeasonId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "LastRecordedWeek",
                table: "Seasons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8c4c4f3-5ea8-4e70-b67f-6f7010c85686", "AQAAAAIAAYagAAAAEGlX7mQKaum16Iy8qFtIQxukWuTi0YlTfofXmQpZZag1vrL35xJrIJeyC3kTk1Ex2Q==", "fa4c5a5a-586b-4d7c-b1b1-98ceff37d8d5" });
        }
    }
}
