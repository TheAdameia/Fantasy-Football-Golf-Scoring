using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class FixScoringTablePleaseGod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce9f8896-eccd-4301-b9a0-594582e05857", "AQAAAAIAAYagAAAAEFIo+qylTWwefmaVfaGpj5UuEjs4XBwxPAHn14/DzxCyUgZzl61jGu0AdaV1NpJrmg==", "12f9b09e-83bd-45ea-a293-0df8f2b87a4a" });

            migrationBuilder.AddColumn<int>(
                name: "AttemptsPassing",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttemptsRushing",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlockedKicks",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Completions",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefenseFumbleRecovery",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExtraPointAttempts",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExtraPointMade",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldGoalAttempts",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldGoalsMade",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FumbleLost",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fumbles",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterceptionDefense",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Interceptions",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointsAgainst",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Receptions",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sacks",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Safety",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Targets",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouchdownsDefense",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouchdownsReceiving",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouchdownsReturn",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouchdownsRushing",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TwoExtraPoints",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YardsPassing",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YardsReceiving",
                table: "Scorings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YardsRushing",
                table: "Scorings",
                type: "integer",
                nullable: true);
            }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fd6ac77-fc4d-4618-a445-29109f9908a6", "AQAAAAIAAYagAAAAEGyCIV+NrYUFPpCaFSNXQ1BIEFKIRwkJiG8gQmqoPXhaxKHfdeVqA741vDmob7wQBQ==", "0cdf35b4-d665-4ca5-a9dd-ea4a9f4650a0" });
            
            migrationBuilder.DropColumn(name: "AttemptsPassing", table: "Scorings");
            migrationBuilder.DropColumn(name: "AttemptsRushing", table: "Scorings");
            migrationBuilder.DropColumn(name: "BlockedKicks", table: "Scorings");
            migrationBuilder.DropColumn(name: "Completions", table: "Scorings");
            migrationBuilder.DropColumn(name: "DefenseFumbleRecovery", table: "Scorings");
            migrationBuilder.DropColumn(name: "ExtraPointAttempts", table: "Scorings");
            migrationBuilder.DropColumn(name: "ExtraPointMade", table: "Scorings");
            migrationBuilder.DropColumn(name: "FieldGoalAttempts", table: "Scorings");
            migrationBuilder.DropColumn(name: "FieldGoalsMade", table: "Scorings");
            migrationBuilder.DropColumn(name: "FumbleLost", table: "Scorings");
            migrationBuilder.DropColumn(name: "Fumbles", table: "Scorings");
            migrationBuilder.DropColumn(name: "InterceptionDefense", table: "Scorings");
            migrationBuilder.DropColumn(name: "Interceptions", table: "Scorings");
            migrationBuilder.DropColumn(name: "PointsAgainst", table: "Scorings");
            migrationBuilder.DropColumn(name: "Receptions", table: "Scorings");
            migrationBuilder.DropColumn(name: "Sacks", table: "Scorings");
            migrationBuilder.DropColumn(name: "Safety", table: "Scorings");
            migrationBuilder.DropColumn(name: "Targets", table: "Scorings");
            migrationBuilder.DropColumn(name: "TouchdownsDefense", table: "Scorings");
            migrationBuilder.DropColumn(name: "TouchdownsReceiving", table: "Scorings");
            migrationBuilder.DropColumn(name: "TouchdownsReturn", table: "Scorings");
            migrationBuilder.DropColumn(name: "TouchdownsRushing", table: "Scorings");
            migrationBuilder.DropColumn(name: "TwoExtraPoints", table: "Scorings");
            migrationBuilder.DropColumn(name: "YardsPassing", table: "Scorings");
            migrationBuilder.DropColumn(name: "YardsReceiving", table: "Scorings");
            migrationBuilder.DropColumn(name: "YardsRushing", table: "Scorings");
        }
    }
}
