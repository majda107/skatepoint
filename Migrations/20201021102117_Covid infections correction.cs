using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace skolu_nepobiram.Migrations
{
    public partial class Covidinfectionscorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Povince",
                table: "ProvinceInfections");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ProvinceInfections",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "ProvinceInfections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ProvinceInfections");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "ProvinceInfections");

            migrationBuilder.AddColumn<string>(
                name: "Povince",
                table: "ProvinceInfections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
