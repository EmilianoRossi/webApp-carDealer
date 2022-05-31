using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp_carDealer.Migrations
{
    public partial class ModifyBuyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelCarBuy",
                table: "Buys");

            migrationBuilder.RenameColumn(
                name: "BrandCarBuy",
                table: "Buys",
                newName: "NameUser");

            migrationBuilder.AddColumn<int>(
                name: "QuantityToBuy",
                table: "Buys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityToBuy",
                table: "Buys");

            migrationBuilder.RenameColumn(
                name: "NameUser",
                table: "Buys",
                newName: "BrandCarBuy");

            migrationBuilder.AddColumn<string>(
                name: "ModelCarBuy",
                table: "Buys",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
