using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeTime.Web.Migrations
{
    public partial class MarkUpdateOnAsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "posts",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "975e0b31-491e-4694-a1bf-4d4346dc00c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a80f7df5-8e24-4298-9147-5ad24f831bdb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d037b9f9-c40c-4db1-a7b7-2a98f9a8f527", "AQAAAAEAACcQAAAAECapqQd1pATd93OsW6UHDPny/2B6EP0nVRYHyYoUbltFzW3FHuJv3aTWLNg9SSfKYQ==", "6de13e42-b5dd-4d5c-8025-0f16349183fe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "posts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3b79722b-be5e-4de5-8885-d0752f6ca324");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f71feea6-fbf6-4f3b-81d1-7fedc2ea815b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "297ccf00-65fd-4556-8e0f-c98e6d79b920", "AQAAAAEAACcQAAAAEAWin6dx3TcNjzL4ouXrdP/6ye2EvkxdiSrGxklpBMTsl3/ocj9M9HDkWbXkv0FMEA==", "49fa20ce-d6af-4ac1-92f3-0e254cd0fbb3" });
        }
    }
}
