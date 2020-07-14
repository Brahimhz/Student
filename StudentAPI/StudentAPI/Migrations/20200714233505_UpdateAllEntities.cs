using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InfoSeanceId",
                table: "Seances");

            migrationBuilder.DropColumn(
                name: "JourneeId",
                table: "Seances");

            migrationBuilder.DropColumn(
                name: "PlanningId",
                table: "Journees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InfoSeanceId",
                table: "Seances",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JourneeId",
                table: "Seances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanningId",
                table: "Journees",
                nullable: false,
                defaultValue: 0);
        }
    }
}
