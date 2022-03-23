using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class ffzx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDesks_DeskType_DeskTypeId",
                table: "WorkingDesks");

            migrationBuilder.DropTable(
                name: "DeskType");

            migrationBuilder.DropIndex(
                name: "IX_WorkingDesks_DeskTypeId",
                table: "WorkingDesks");

            migrationBuilder.DropColumn(
                name: "Booked",
                table: "WorkingDesks");

            migrationBuilder.DropColumn(
                name: "DeskTypeId",
                table: "WorkingDesks");

            migrationBuilder.DropColumn(
                name: "HasHeadset",
                table: "WorkingDesks");

            migrationBuilder.DropColumn(
                name: "HasKeyboard",
                table: "WorkingDesks");

            migrationBuilder.DropColumn(
                name: "HasMonitor",
                table: "WorkingDesks");

            migrationBuilder.DropColumn(
                name: "HasMouse",
                table: "WorkingDesks");

            migrationBuilder.RenameColumn(
                name: "HasPC",
                table: "WorkingDesks",
                newName: "HasComputer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasComputer",
                table: "WorkingDesks",
                newName: "HasPC");

            migrationBuilder.AddColumn<bool>(
                name: "Booked",
                table: "WorkingDesks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DeskTypeId",
                table: "WorkingDesks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasHeadset",
                table: "WorkingDesks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasKeyboard",
                table: "WorkingDesks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMonitor",
                table: "WorkingDesks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMouse",
                table: "WorkingDesks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DeskType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeskTypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDesks_DeskTypeId",
                table: "WorkingDesks",
                column: "DeskTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDesks_DeskType_DeskTypeId",
                table: "WorkingDesks",
                column: "DeskTypeId",
                principalTable: "DeskType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
