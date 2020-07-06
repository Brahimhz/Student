using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateResultatEntityVer02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MoyenneMatiere",
                table: "ResultatMatieres",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoyenneMatiere",
                table: "ResultatMatieres");
        }
    }
}
