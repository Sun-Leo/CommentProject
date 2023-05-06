using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class category_commments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Comments",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CategoryID",
                table: "Comments",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Categories_CategoryID",
                table: "Comments",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Categories_CategoryID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CategoryID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Comments");
        }
    }
}
