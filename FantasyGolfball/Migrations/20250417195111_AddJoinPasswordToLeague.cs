using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddJoinPasswordToLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SeasonStartDate",
                table: "Seasons",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DraftStartTime",
                table: "Leagues",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "JoinPassword",
                table: "Leagues",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ActivePeriods",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "ActivePeriods",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "680aeb28-ef9b-4c11-b8cb-4aa609e2a4f7", "AQAAAAIAAYagAAAAENAD1wyvU1KxB61q7RnLQA3PK+x3kIBG4Q0kAFZnz68Sm36TZROx7ExLZ7JbJIvY8Q==", "020628a7-0ec6-451f-b431-30728aec8883" });

            migrationBuilder.UpdateData(
                table: "Leagues",
                keyColumn: "LeagueId",
                keyValue: 1,
                column: "JoinPassword",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinPassword",
                table: "Leagues");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SeasonStartDate",
                table: "Seasons",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DraftStartTime",
                table: "Leagues",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Start",
                table: "ActivePeriods",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "ActivePeriods",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1015fd3-4853-4594-af1e-cab9f94441f3", "AQAAAAIAAYagAAAAEHTfMXRr29rgpX5tuhytT2Q+PiRo2oZJ4ES+aAUIuRug9iPhRmVT0l1Uz+mDmLWwqw==", "d0469efb-af2c-46ba-a1aa-d75ae1f402d5" });
        }
    }
}
