using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeTime.Web.Migrations
{
    public partial class AddWriterFieldToPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_posts_WriterId",
                table: "posts",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_AspNetUsers_WriterId",
                table: "posts",
                column: "WriterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_WriterId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_WriterId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "posts");
        }
    }
}
