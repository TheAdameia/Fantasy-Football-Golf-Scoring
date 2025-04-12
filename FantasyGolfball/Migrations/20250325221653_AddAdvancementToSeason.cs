using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGolfball.Migrations
{
    /// <inheritdoc />
    public partial class AddAdvancementToSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Advancement",
                table: "Seasons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8703d06b-436a-4944-ae6b-3c06b1651b69", "AQAAAAIAAYagAAAAEOY6FQr3zk2G57+IRk823FcPoF6/aMec//dpbJGHTxUmFrmk12Mew5cB1a6Sq2FzHA==", "a1463efb-bc20-4b5b-bcec-67d5e7824e9d" });

            migrationBuilder.UpdateData(
                table: "Seasons",
                keyColumn: "SeasonId",
                keyValue: 1,
                column: "Advancement",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Advancement",
                table: "Seasons");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25fd4f2e-2c57-41aa-95fd-b62db52cf5e3", "AQAAAAIAAYagAAAAEELYAlqzL0k48Dud6ahMriFfG86GU65P6Sjlqyy1TF2NQqQdnx/LhI5eP3Qy0i8Bpg==", "23fb6c22-48fb-42f9-8d10-8ba12ab884cd" });
        }
    }
}
