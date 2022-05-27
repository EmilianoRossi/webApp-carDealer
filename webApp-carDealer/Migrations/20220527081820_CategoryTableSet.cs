using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp_carDealer.Migrations
{
    public partial class CategoryTableSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Category_CategoryId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Category_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
