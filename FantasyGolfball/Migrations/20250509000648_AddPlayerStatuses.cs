using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Statuses_StatusId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Players",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "playerStatuses",
                columns: table => new
                {
                    PlayerStatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    StatusStartWeek = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerStatuses", x => x.PlayerStatusId);
                    table.ForeignKey(
                        name: "FK_playerStatuses_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playerStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13c98b23-18c7-4f72-a04b-b214dd2ac294", "AQAAAAIAAYagAAAAEBHhsaQMOF3gWxjvLE9EDlQWu2K4gUkqH71WWBZNoaMRciaE6QglB5uaZpzfradzMg==", "a948d88f-aea0-429a-a8d3-33781798430e" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 6,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 7,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 8,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 9,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 10,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 11,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 12,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 13,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 14,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 15,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 16,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 17,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 18,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 19,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 20,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 21,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 22,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 23,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 24,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 25,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 26,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 27,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 28,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 29,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 30,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 31,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 32,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 33,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 34,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 35,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 36,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 37,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 38,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 39,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 40,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 41,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 42,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 43,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 44,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 45,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 46,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 47,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 48,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 49,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 50,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 51,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 52,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 53,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 54,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 55,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 56,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 57,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 58,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 59,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 60,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 61,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 62,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 63,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 64,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 65,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 66,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 67,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 68,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 69,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 70,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 71,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 72,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 73,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 74,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 75,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 76,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 77,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 78,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 79,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 80,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 81,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 82,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 83,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 84,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 85,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 86,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 87,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 88,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 89,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 90,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 91,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 92,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 93,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 94,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 95,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 96,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 97,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 98,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 99,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 100,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 101,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 102,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 103,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 104,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 105,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 106,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 107,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 108,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 109,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 110,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 111,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 112,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 113,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 114,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 115,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 116,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 117,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 118,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 119,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 120,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 121,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 122,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 123,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 124,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 125,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 126,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 127,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 128,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 129,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 130,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 131,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 132,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 133,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 134,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 135,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 136,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 137,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 138,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 139,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 140,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 141,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 142,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 143,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 144,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 145,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 146,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 147,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 148,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 149,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 150,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 151,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 152,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 153,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 154,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 155,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 156,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 157,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 158,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 159,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 160,
                column: "StatusId",
                value: null);

            migrationBuilder.InsertData(
                table: "playerStatuses",
                columns: new[] { "PlayerStatusId", "PlayerId", "StatusId", "StatusStartWeek" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 1, 1 },
                    { 5, 5, 1, 1 },
                    { 6, 6, 1, 1 },
                    { 7, 7, 1, 1 },
                    { 8, 8, 1, 1 },
                    { 9, 9, 1, 1 },
                    { 10, 10, 1, 1 },
                    { 11, 11, 1, 1 },
                    { 12, 12, 1, 1 },
                    { 13, 13, 1, 1 },
                    { 14, 14, 1, 1 },
                    { 15, 15, 1, 1 },
                    { 16, 16, 1, 1 },
                    { 17, 17, 1, 1 },
                    { 18, 18, 1, 1 },
                    { 19, 19, 1, 1 },
                    { 20, 20, 1, 1 },
                    { 21, 21, 1, 1 },
                    { 22, 22, 1, 1 },
                    { 23, 23, 1, 1 },
                    { 24, 24, 1, 1 },
                    { 25, 25, 1, 1 },
                    { 26, 26, 1, 1 },
                    { 27, 27, 1, 1 },
                    { 28, 28, 1, 1 },
                    { 29, 29, 1, 1 },
                    { 30, 30, 1, 1 },
                    { 31, 31, 1, 1 },
                    { 32, 32, 1, 1 },
                    { 33, 33, 1, 1 },
                    { 34, 34, 1, 1 },
                    { 35, 35, 1, 1 },
                    { 36, 36, 1, 1 },
                    { 37, 37, 1, 1 },
                    { 38, 38, 1, 1 },
                    { 39, 39, 1, 1 },
                    { 40, 40, 1, 1 },
                    { 41, 41, 1, 1 },
                    { 42, 42, 1, 1 },
                    { 43, 43, 1, 1 },
                    { 44, 44, 1, 1 },
                    { 45, 45, 1, 1 },
                    { 46, 46, 1, 1 },
                    { 47, 47, 1, 1 },
                    { 48, 48, 1, 1 },
                    { 49, 49, 1, 1 },
                    { 50, 50, 1, 1 },
                    { 51, 51, 1, 1 },
                    { 52, 52, 1, 1 },
                    { 53, 53, 1, 1 },
                    { 54, 54, 1, 1 },
                    { 55, 55, 1, 1 },
                    { 56, 56, 1, 1 },
                    { 57, 57, 1, 1 },
                    { 58, 58, 1, 1 },
                    { 59, 59, 1, 1 },
                    { 60, 60, 1, 1 },
                    { 61, 61, 1, 1 },
                    { 62, 62, 1, 1 },
                    { 63, 63, 1, 1 },
                    { 64, 64, 1, 1 },
                    { 65, 65, 1, 1 },
                    { 66, 66, 1, 1 },
                    { 67, 67, 1, 1 },
                    { 68, 68, 1, 1 },
                    { 69, 69, 1, 1 },
                    { 70, 70, 1, 1 },
                    { 71, 71, 1, 1 },
                    { 72, 72, 1, 1 },
                    { 73, 73, 1, 1 },
                    { 74, 74, 1, 1 },
                    { 75, 75, 1, 1 },
                    { 76, 76, 1, 1 },
                    { 77, 77, 1, 1 },
                    { 78, 78, 1, 1 },
                    { 79, 79, 1, 1 },
                    { 80, 80, 1, 1 },
                    { 81, 81, 1, 1 },
                    { 82, 82, 1, 1 },
                    { 83, 83, 1, 1 },
                    { 84, 84, 1, 1 },
                    { 85, 85, 1, 1 },
                    { 86, 86, 1, 1 },
                    { 87, 87, 1, 1 },
                    { 88, 88, 1, 1 },
                    { 89, 89, 1, 1 },
                    { 90, 90, 1, 1 },
                    { 91, 91, 1, 1 },
                    { 92, 92, 1, 1 },
                    { 93, 93, 1, 1 },
                    { 94, 94, 1, 1 },
                    { 95, 95, 1, 1 },
                    { 96, 96, 1, 1 },
                    { 97, 97, 1, 1 },
                    { 98, 98, 1, 1 },
                    { 99, 99, 1, 1 },
                    { 100, 100, 1, 1 },
                    { 101, 101, 1, 1 },
                    { 102, 102, 1, 1 },
                    { 103, 103, 1, 1 },
                    { 104, 104, 1, 1 },
                    { 105, 105, 1, 1 },
                    { 106, 106, 1, 1 },
                    { 107, 107, 1, 1 },
                    { 108, 108, 1, 1 },
                    { 109, 109, 1, 1 },
                    { 110, 110, 1, 1 },
                    { 111, 111, 1, 1 },
                    { 112, 112, 1, 1 },
                    { 113, 113, 1, 1 },
                    { 114, 114, 1, 1 },
                    { 115, 115, 1, 1 },
                    { 116, 116, 1, 1 },
                    { 117, 117, 1, 1 },
                    { 118, 118, 1, 1 },
                    { 119, 119, 1, 1 },
                    { 120, 120, 1, 1 },
                    { 121, 121, 1, 1 },
                    { 122, 122, 1, 1 },
                    { 123, 123, 1, 1 },
                    { 124, 124, 1, 1 },
                    { 125, 125, 1, 1 },
                    { 126, 126, 1, 1 },
                    { 127, 127, 1, 1 },
                    { 128, 128, 1, 1 },
                    { 129, 129, 1, 1 },
                    { 130, 130, 1, 1 },
                    { 131, 131, 1, 1 },
                    { 132, 132, 1, 1 },
                    { 133, 133, 1, 1 },
                    { 134, 134, 1, 1 },
                    { 135, 135, 1, 1 },
                    { 136, 136, 1, 1 },
                    { 137, 137, 1, 1 },
                    { 138, 138, 1, 1 },
                    { 139, 139, 1, 1 },
                    { 140, 140, 1, 1 },
                    { 141, 141, 1, 1 },
                    { 142, 142, 1, 1 },
                    { 143, 143, 1, 1 },
                    { 144, 144, 1, 1 },
                    { 145, 145, 1, 1 },
                    { 146, 146, 1, 1 },
                    { 147, 147, 1, 1 },
                    { 148, 148, 1, 1 },
                    { 149, 149, 1, 1 },
                    { 150, 150, 1, 1 },
                    { 151, 151, 1, 1 },
                    { 152, 152, 1, 1 },
                    { 153, 153, 1, 1 },
                    { 154, 154, 1, 1 },
                    { 155, 155, 1, 1 },
                    { 156, 156, 1, 1 },
                    { 157, 157, 1, 1 },
                    { 158, 158, 1, 1 },
                    { 159, 159, 1, 1 },
                    { 160, 160, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_playerStatuses_PlayerId",
                table: "playerStatuses",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_playerStatuses_StatusId",
                table: "playerStatuses",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Statuses_StatusId",
                table: "Players",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Statuses_StatusId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "playerStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73ead475-00a6-4d06-9155-dc662a8bae87", "AQAAAAIAAYagAAAAEGkzthEBYTXqJkxt7ufDfyY0gL5qqecmkUr1TP502pR93bCP2qfoE0iNHLX6sP/c6Q==", "48649f21-2e0b-4312-9d66-db07d5e43038" });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 6,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 7,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 8,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 9,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 10,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 11,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 12,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 13,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 14,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 15,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 16,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 17,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 18,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 19,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 20,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 21,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 22,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 23,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 24,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 25,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 26,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 27,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 28,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 29,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 30,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 31,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 32,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 33,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 34,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 35,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 36,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 37,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 38,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 39,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 40,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 41,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 42,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 43,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 44,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 45,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 46,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 47,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 48,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 49,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 50,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 51,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 52,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 53,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 54,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 55,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 56,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 57,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 58,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 59,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 60,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 61,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 62,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 63,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 64,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 65,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 66,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 67,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 68,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 69,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 70,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 71,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 72,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 73,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 74,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 75,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 76,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 77,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 78,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 79,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 80,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 81,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 82,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 83,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 84,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 85,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 86,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 87,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 88,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 89,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 90,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 91,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 92,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 93,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 94,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 95,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 96,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 97,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 98,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 99,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 100,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 101,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 102,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 103,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 104,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 105,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 106,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 107,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 108,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 109,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 110,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 111,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 112,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 113,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 114,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 115,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 116,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 117,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 118,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 119,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 120,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 121,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 122,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 123,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 124,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 125,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 126,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 127,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 128,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 129,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 130,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 131,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 132,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 133,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 134,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 135,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 136,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 137,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 138,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 139,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 140,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 141,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 142,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 143,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 144,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 145,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 146,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 147,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 148,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 149,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 150,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 151,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 152,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 153,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 154,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 155,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 156,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 157,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 158,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 159,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 160,
                column: "StatusId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Statuses_StatusId",
                table: "Players",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
