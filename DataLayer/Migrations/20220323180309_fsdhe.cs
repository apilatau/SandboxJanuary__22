using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class fsdhe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Reserves",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_OfficeId",
                table: "Reserves",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Offices_OfficeId",
                table: "Reserves",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Offices_OfficeId",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_OfficeId",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Reserves");
        }
    }
}
