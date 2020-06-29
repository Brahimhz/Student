using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateParcourEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcours",
                table: "Parcours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcours",
                table: "Parcours",
                columns: new[] { "NiveauSpecialiteId", "EtudientId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcours",
                table: "Parcours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcours",
                table: "Parcours",
                columns: new[] { "NiveauSpecialiteId", "EtudientId" });
        }
    }
}
