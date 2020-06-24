using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class deleteClassNbr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreGroupe",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "NombreSGrope",
                table: "Groupes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NombreGroupe",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NombreSGrope",
                table: "Groupes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
