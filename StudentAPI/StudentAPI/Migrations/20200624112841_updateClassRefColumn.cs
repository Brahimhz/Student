using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class updateClassRefColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefSection",
                table: "SousGroupes",
                newName: "RefSousGroupe");

            migrationBuilder.RenameColumn(
                name: "RefSection",
                table: "Groupes",
                newName: "RefGroupe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefSousGroupe",
                table: "SousGroupes",
                newName: "RefSection");

            migrationBuilder.RenameColumn(
                name: "RefGroupe",
                table: "Groupes",
                newName: "RefSection");
        }
    }
}
