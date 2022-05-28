using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp_carDealer.Migrations
{
    public partial class DateAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "Refiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "Refiles");
        }
    }
}
