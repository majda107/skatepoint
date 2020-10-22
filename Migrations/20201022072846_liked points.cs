using Microsoft.EntityFrameworkCore.Migrations;

namespace skolu_nepobiram.Migrations
{
    public partial class likedpoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkatePlaceId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SkatePlaceId",
                table: "AspNetUsers",
                column: "SkatePlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SkatePlaces_SkatePlaceId",
                table: "AspNetUsers",
                column: "SkatePlaceId",
                principalTable: "SkatePlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SkatePlaces_SkatePlaceId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SkatePlaceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SkatePlaceId",
                table: "AspNetUsers");
        }
    }
}
