using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeTime.Web.Migrations
{
    public partial class ChangePostTagTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTagEntity_posts_PostId",
                table: "PostTagEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTagEntity_Tags_TagId",
                table: "PostTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTagEntity",
                table: "PostTagEntity");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "posts");

            migrationBuilder.RenameTable(
                name: "PostTagEntity",
                newName: "PostTags");

            migrationBuilder.RenameIndex(
                name: "IX_PostTagEntity_TagId",
                table: "PostTags",
                newName: "IX_PostTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "622aab26-26ad-4c12-8cbe-f2fa505433af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e4d97e0f-f047-47b8-b4a5-0981130554f7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82e4286f-a1de-4b1a-b16d-b31c63e9b7f6", "AQAAAAEAACcQAAAAEN+ZKPfaEkt3MjksBBe+pIgaAzVgK+STAYcND8lCcK02Jclm8xySgTzNnR+nGMCYEA==", "741ee7ed-5473-44ef-a941-8499cc421742" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Tags_TagId",
                table: "PostTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_posts_PostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Tags_TagId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "PostTagEntity");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_TagId",
                table: "PostTagEntity",
                newName: "IX_PostTagEntity_TagId");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTagEntity",
                table: "PostTagEntity",
                columns: new[] { "PostId", "TagId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagEntity_posts_PostId",
                table: "PostTagEntity",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagEntity_Tags_TagId",
                table: "PostTagEntity",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
