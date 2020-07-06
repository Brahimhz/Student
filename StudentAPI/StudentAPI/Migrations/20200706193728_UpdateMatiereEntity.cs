using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateMatiereEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultatMatieres_Matieres_MatiereRefId_MatiereNiveauSpecialiteId_MatiereUnitePedagogiqueId",
                table: "ResultatMatieres");

            migrationBuilder.DropIndex(
                name: "IX_ResultatMatieres_MatiereRefId_MatiereNiveauSpecialiteId_MatiereUnitePedagogiqueId",
                table: "ResultatMatieres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matieres",
                table: "Matieres");

            migrationBuilder.DropColumn(
                name: "MatiereNiveauSpecialiteId",
                table: "ResultatMatieres");

            migrationBuilder.DropColumn(
                name: "MatiereRefId",
                table: "ResultatMatieres");

            migrationBuilder.DropColumn(
                name: "MatiereUnitePedagogiqueId",
                table: "ResultatMatieres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Matieres");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultatMatieres_Matieres_MatiereId",
                table: "ResultatMatieres");

            migrationBuilder.DropIndex(
                name: "IX_ResultatMatieres_MatiereId",
                table: "ResultatMatieres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matieres",
                table: "Matieres");

            migrationBuilder.DropIndex(
                name: "IX_Matieres_MatiereRefId",
                table: "Matieres");

            migrationBuilder.AddColumn<int>(
                name: "MatiereNiveauSpecialiteId",
                table: "ResultatMatieres",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatiereRefId",
                table: "ResultatMatieres",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatiereUnitePedagogiqueId",
                table: "ResultatMatieres",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Matieres",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matieres",
                table: "Matieres",
                columns: new[] { "MatiereRefId", "NiveauSpecialiteId", "UnitePedagogiqueId" });

            migrationBuilder.CreateIndex(
                name: "IX_ResultatMatieres_MatiereRefId_MatiereNiveauSpecialiteId_MatiereUnitePedagogiqueId",
                table: "ResultatMatieres",
                columns: new[] { "MatiereRefId", "MatiereNiveauSpecialiteId", "MatiereUnitePedagogiqueId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ResultatMatieres_Matieres_MatiereRefId_MatiereNiveauSpecialiteId_MatiereUnitePedagogiqueId",
                table: "ResultatMatieres",
                columns: new[] { "MatiereRefId", "MatiereNiveauSpecialiteId", "MatiereUnitePedagogiqueId" },
                principalTable: "Matieres",
                principalColumns: new[] { "MatiereRefId", "NiveauSpecialiteId", "UnitePedagogiqueId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
