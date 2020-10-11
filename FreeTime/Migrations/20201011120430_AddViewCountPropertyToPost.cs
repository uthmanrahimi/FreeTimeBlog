using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeTime.Web.Migrations
{
    public partial class AddViewCountPropertyToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b45ea090-dde0-46ba-bcd1-aa4508fc23b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "efa9fa60-7fd8-4763-ade1-80292a63bf0e", "member" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "130c0a39-1cc2-4159-a28d-88b8606b18a2", "AQAAAAEAACcQAAAAENH3Hgux5gS1jfxMDilD8ef8dNPCblBI2p7c08SmPjoL/GMXlzY/0NXunbSSjGUtIA==", "613483ef-c219-45d7-be7d-72913f07ed6e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "posts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cd6dca1f-896d-4ad3-a437-282d838e6cd7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "6fc07da2-b907-452c-ab19-e64da71aece4", "user" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43ace364-8cd5-4fb7-a4c7-0be2626fe941", "AQAAAAEAACcQAAAAELLNxZtpBlktAjlkGbRX6CY5bDG8SrrTjNT5gJQz6nd4xKSUmX8cU/TAMjqAU/MDVQ==", "886d2881-0d95-4c3a-952d-56a3983025a8" });
        }
    }
}
