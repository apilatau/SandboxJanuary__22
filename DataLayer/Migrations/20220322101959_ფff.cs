using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class ფff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDesks_DeskType_DeskTypeId",
                table: "WorkingDesks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDesks_Maps_MapId",
                table: "WorkingDesks");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "WorkingDesks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DeskTypeId",
                table: "WorkingDesks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDesks_DeskType_DeskTypeId",
                table: "WorkingDesks",
                column: "DeskTypeId",
                principalTable: "DeskType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDesks_Maps_MapId",
                table: "WorkingDesks",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDesks_DeskType_DeskTypeId",
                table: "WorkingDesks");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDesks_Maps_MapId",
                table: "WorkingDesks");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "WorkingDesks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeskTypeId",
                table: "WorkingDesks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDesks_DeskType_DeskTypeId",
                table: "WorkingDesks",
                column: "DeskTypeId",
                principalTable: "DeskType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDesks_Maps_MapId",
                table: "WorkingDesks",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
