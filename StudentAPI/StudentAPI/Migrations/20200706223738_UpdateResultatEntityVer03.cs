using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateResultatEntityVer03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Credit",
                table: "Resultats",
                newName: "TotalCredit");

            migrationBuilder.AddColumn<double>(
                name: "TotalCoff",
                table: "ResultatUnites",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Resultats",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCoff",
                table: "Resultats",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalMatiere",
                table: "ResultatMatieres",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCoff",
                table: "ResultatUnites");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Resultats");

            migrationBuilder.DropColumn(
                name: "TotalCoff",
                table: "Resultats");

            migrationBuilder.DropColumn(
                name: "TotalMatiere",
                table: "ResultatMatieres");

            migrationBuilder.RenameColumn(
                name: "TotalCredit",
                table: "Resultats",
                newName: "Credit");
        }
    }
}
