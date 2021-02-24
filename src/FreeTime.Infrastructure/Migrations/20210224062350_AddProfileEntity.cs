using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeTime.Infrastructure.Migrations
{
    public partial class AddProfileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackOverflowProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GithubProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterProfile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9dc6cb2b-f51f-428f-bbe4-c84c6989a2ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a8f3bc05-09c5-4e3b-a506-8967c92a56d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b189d317-3be5-4d37-9630-c3a17aa67e4f", "AQAAAAEAACcQAAAAEGja8p8q5g6i2twYwL9TU++TCzyJ6t9gctIfXmCBiN7wYv7L40Fuul/REyepuznOCA==", "0d38ac1b-c549-4f92-8728-350e094bebb9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "78cf3b24-1f25-49ed-b7d1-0d3054d59c17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bc3f9807-d7a7-4e64-98a1-af7adbf58a44");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12b599dd-b742-4e8d-aebc-d1163c47b873", "AQAAAAEAACcQAAAAEA/it/C/xHOLcxH/O/n8sFPjBwkI4vtW0dgDoTdNZV1cOySGinnnLMf5DJo7xzVAWQ==", "a66e18b0-5fa1-46b9-8e50-b48d9aa40f1e" });
        }
    }
}
