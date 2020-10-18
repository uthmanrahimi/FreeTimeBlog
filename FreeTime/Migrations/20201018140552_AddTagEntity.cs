using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeTime.Web.Migrations
{
    public partial class AddTagEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "posts",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TagEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTagEntity",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagEntity", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagEntity_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagEntity_TagEntity_TagId",
                        column: x => x.TagId,
                        principalTable: "TagEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4f71655d-57fa-4ad0-bc3f-8c05c693fa12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7ab2043b-46a8-4e1f-8034-6dfc5394aaad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b52d03e-9648-40ec-ad62-ab79474ec48f", "AQAAAAEAACcQAAAAEN26S2DV+p60udgrG0e+2FQF34IofmME4fOjxC45/eGhjSp8jNv5uD7Nyc1Vz2KtTw==", "15023984-8883-4cb5-942e-72fcacbcb97e" });

            migrationBuilder.CreateIndex(
                name: "IX_PostTagEntity_TagId",
                table: "PostTagEntity",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTagEntity");

            migrationBuilder.DropTable(
                name: "TagEntity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "posts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

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
                column: "ConcurrencyStamp",
                value: "efa9fa60-7fd8-4763-ade1-80292a63bf0e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "130c0a39-1cc2-4159-a28d-88b8606b18a2", "AQAAAAEAACcQAAAAENH3Hgux5gS1jfxMDilD8ef8dNPCblBI2p7c08SmPjoL/GMXlzY/0NXunbSSjGUtIA==", "613483ef-c219-45d7-be7d-72913f07ed6e" });
        }
    }
}
