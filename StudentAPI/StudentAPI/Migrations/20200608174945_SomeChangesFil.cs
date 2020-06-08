using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class SomeChangesFil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filieres_DomaineFormations_DomaineFormationDepartementId_DomaineFormationFormationId",
                table: "Filieres");

            migrationBuilder.DropIndex(
                name: "IX_Filieres_DomaineFormationDepartementId_DomaineFormationFormationId",
                table: "Filieres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DomaineFormations",
                table: "DomaineFormations");

            migrationBuilder.DropColumn(
                name: "DomaineFormationDepartementId",
                table: "Filieres");

            migrationBuilder.DropColumn(
                name: "DomaineFormationFormationId",
                table: "Filieres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DomaineFormations",
                table: "DomaineFormations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Filieres_DomaineFormationId",
                table: "Filieres",
                column: "DomaineFormationId");

            migrationBuilder.CreateIndex(
                name: "IX_DomaineFormations_DepartementId",
                table: "DomaineFormations",
                column: "DepartementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filieres_DomaineFormations_DomaineFormationId",
                table: "Filieres",
                column: "DomaineFormationId",
                principalTable: "DomaineFormations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filieres_DomaineFormations_DomaineFormationId",
                table: "Filieres");

            migrationBuilder.DropIndex(
                name: "IX_Filieres_DomaineFormationId",
                table: "Filieres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DomaineFormations",
                table: "DomaineFormations");

            migrationBuilder.DropIndex(
                name: "IX_DomaineFormations_DepartementId",
                table: "DomaineFormations");

            migrationBuilder.AddColumn<int>(
                name: "DomaineFormationDepartementId",
                table: "Filieres",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DomaineFormationFormationId",
                table: "Filieres",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DomaineFormations",
                table: "DomaineFormations",
                columns: new[] { "DepartementId", "FormationId" });

            migrationBuilder.CreateIndex(
                name: "IX_Filieres_DomaineFormationDepartementId_DomaineFormationFormationId",
                table: "Filieres",
                columns: new[] { "DomaineFormationDepartementId", "DomaineFormationFormationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Filieres_DomaineFormations_DomaineFormationDepartementId_DomaineFormationFormationId",
                table: "Filieres",
                columns: new[] { "DomaineFormationDepartementId", "DomaineFormationFormationId" },
                principalTable: "DomaineFormations",
                principalColumns: new[] { "DepartementId", "FormationId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
