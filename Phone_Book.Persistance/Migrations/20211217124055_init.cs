using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phone_Book.Persistance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 17, 16, 10, 54, 129, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 17, 16, 10, 54, 137, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 17, 16, 10, 54, 137, DateTimeKind.Local).AddTicks(8421));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 17, 15, 58, 0, 168, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 17, 15, 58, 0, 173, DateTimeKind.Local).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 12, 17, 15, 58, 0, 173, DateTimeKind.Local).AddTicks(5491));
        }
    }
}
