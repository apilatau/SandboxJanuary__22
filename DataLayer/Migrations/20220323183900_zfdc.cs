using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class zfdc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "WorkingDesks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDesks_OfficeId",
                table: "WorkingDesks",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDesks_Offices_OfficeId",
                table: "WorkingDesks",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDesks_Offices_OfficeId",
                table: "WorkingDesks");

            migrationBuilder.DropIndex(
                name: "IX_WorkingDesks_OfficeId",
                table: "WorkingDesks");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "WorkingDesks");
        }
    }
}
