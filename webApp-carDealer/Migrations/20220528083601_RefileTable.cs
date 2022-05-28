using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp_carDealer.Migrations
{
    public partial class RefileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BrandCarBuy",
                table: "Buys",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBuy",
                table: "Buys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Refiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSupplier = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    PriceRefile = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refiles_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Refiles_CarId",
                table: "Refiles",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Refiles");

            migrationBuilder.DropColumn(
                name: "DateBuy",
                table: "Buys");

            migrationBuilder.AlterColumn<string>(
                name: "BrandCarBuy",
                table: "Buys",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
