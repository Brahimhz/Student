using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateSeanceTablev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassNbr",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "Modules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassNbr",
                table: "Modules",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolYear",
                table: "Modules",
                maxLength: 20,
                nullable: true);
        }
    }
}
