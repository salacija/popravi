using Microsoft.EntityFrameworkCore.Migrations;

namespace Popravi.DataAccess.Migrations
{
    public partial class UpdatedtableCityaddedZipCodeproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Cities",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ZipCode",
                table: "Cities",
                column: "ZipCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cities_ZipCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Cities");
        }
    }
}
