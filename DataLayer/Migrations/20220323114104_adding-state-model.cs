using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class addingstatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerTelegramId = table.Column<long>(type: "bigint", nullable: true),
                    TargetTelegramId = table.Column<long>(type: "bigint", nullable: true),
                    cityName = table.Column<string>(type: "text", nullable: true),
                    officeName = table.Column<string>(type: "text", nullable: true),
                    WorkingDeskNumber = table.Column<int>(type: "integer", nullable: true),
                    startDay = table.Column<string>(type: "text", nullable: true),
                    startMonth = table.Column<string>(type: "text", nullable: true),
                    endDay = table.Column<string>(type: "text", nullable: true),
                    endMonth = table.Column<string>(type: "text", nullable: true),
                    userNumber = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
