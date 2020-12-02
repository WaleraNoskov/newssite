using Microsoft.EntityFrameworkCore.Migrations;

namespace newsSite.Migrations
{
    public partial class addCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "СategoryId",
                table: "BlogPosts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_СategoryId",
                table: "BlogPosts",
                column: "СategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Category_СategoryId",
                table: "BlogPosts",
                column: "СategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Category_СategoryId",
                table: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_СategoryId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "СategoryId",
                table: "BlogPosts");
        }
    }
}
