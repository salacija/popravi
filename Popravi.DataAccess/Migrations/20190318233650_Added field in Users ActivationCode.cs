using Microsoft.EntityFrameworkCore.Migrations;

namespace Popravi.DataAccess.Migrations
{
    public partial class AddedfieldinUsersActivationCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivationCode",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActivationCode",
                table: "Users",
                column: "ActivationCode",
                unique: true,
                filter: "[ActivationCode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_ActivationCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "Users");
        }
    }
}
