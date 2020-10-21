using Microsoft.EntityFrameworkCore.Migrations;

namespace skolu_nepobiram.Migrations
{
    public partial class skateplacemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SkatePlaces",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "SkatePlaces",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "SkatePlaces",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SkatePlaces",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "SkatePlaces");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "SkatePlaces");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "SkatePlaces");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SkatePlaces");
        }
    }
}
