using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class fsdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityNumb",
                table: "States",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeNumb",
                table: "States",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityNumb",
                table: "States");

            migrationBuilder.DropColumn(
                name: "OfficeNumb",
                table: "States");
        }
    }
}
