using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Popravi.DataAccess.Migrations
{
    public partial class setupinitalroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name" },
                values: new object[] { 4, new DateTime(2019, 4, 12, 22, 48, 1, 188, DateTimeKind.Local).AddTicks(474), true, "User" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name" },
                values: new object[] { 1, new DateTime(2019, 4, 12, 22, 48, 1, 192, DateTimeKind.Local).AddTicks(815), true, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
