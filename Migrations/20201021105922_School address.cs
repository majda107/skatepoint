using Microsoft.EntityFrameworkCore.Migrations;

namespace skolu_nepobiram.Migrations
{
    public partial class Schooladdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Schools",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalName",
                table: "Schools",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "PrincipalName",
                table: "Schools");
        }
    }
}
