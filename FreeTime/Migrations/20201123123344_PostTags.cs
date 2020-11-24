using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeTime.Web.Migrations
{
    public partial class PostTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTagEntity_TagEntity_TagId",
                table: "PostTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagEntity",
                table: "TagEntity");

            migrationBuilder.RenameTable(
                name: "TagEntity",
                newName: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserTokens",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserLogins",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserClaims",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoleClaims",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

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
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 },
                column: "Discriminator",
                value: "UserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 2 },
                column: "Discriminator",
                value: "UserRole");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "297ccf00-65fd-4556-8e0f-c98e6d79b920", "AQAAAAEAACcQAAAAEAWin6dx3TcNjzL4ouXrdP/6ye2EvkxdiSrGxklpBMTsl3/ocj9M9HDkWbXkv0FMEA==", "49fa20ce-d6af-4ac1-92f3-0e254cd0fbb3" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagEntity_Tags_TagId",
                table: "PostTagEntity",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTagEntity_Tags_TagId",
                table: "PostTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "TagEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagEntity",
                table: "TagEntity",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagEntity_TagEntity_TagId",
                table: "PostTagEntity",
                column: "TagId",
                principalTable: "TagEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
