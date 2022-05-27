using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp_carDealer.Migrations
{
    public partial class LikeQuantityAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Like",
                table: "Cars",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cars");
        }
    }
}
