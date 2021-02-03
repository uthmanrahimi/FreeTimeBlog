using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeTime.Infrastructure.Migrations
{
    public partial class ChangePostTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_posts_PostId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "posts");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "00e09ed2-5aaf-4d9f-b6f8-5f514d6141a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7dbdb91f-9528-4625-bf6f-e4235d6d53de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3733e0c1-eeb0-4af8-ae85-684370f5693e", "AQAAAAEAACcQAAAAELLrL5A7fVUcdNzavwEGYYwhrDBPII7K7hCyzBreHV+t9x0NfuNkQfb2E1AFb6r8Ew==", "58a61ac2-d26c-46d4-8788-d43dfa3a9e54" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
