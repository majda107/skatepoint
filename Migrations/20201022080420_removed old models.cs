using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace skolu_nepobiram.Migrations
{
    public partial class removedoldmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvinceInfections");

            migrationBuilder.DropTable(
                name: "Schools");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProvinceInfections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Died = table.Column<int>(type: "int", nullable: false),
                    Infected = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceLau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recovered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceInfections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    ICO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacityUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrincipalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.ICO);
                });
        }
    }
}
