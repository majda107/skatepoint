using Microsoft.EntityFrameworkCore.Migrations;

namespace skolu_nepobiram.Migrations
{
    public partial class usermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SkatePlaces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkatePlaces_ApplicationUserId",
                table: "SkatePlaces",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkatePlaces_AspNetUsers_ApplicationUserId",
                table: "SkatePlaces",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkatePlaces_AspNetUsers_ApplicationUserId",
                table: "SkatePlaces");

            migrationBuilder.DropIndex(
                name: "IX_SkatePlaces_ApplicationUserId",
                table: "SkatePlaces");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SkatePlaces");
        }
    }
}
