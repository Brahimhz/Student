using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateInfoSeanceVer02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_EnseignatId",
                table: "InfoSeances");

            migrationBuilder.RenameColumn(
                name: "MatiereRefId",
                table: "InfoSeances",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "MatiereId",
                table: "InfoSeances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_MatiereId",
                table: "InfoSeances",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_EnseignatId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances",
                columns: new[] { "EnseignatId", "JourneeId", "SeanceId", "SalleId" },
                unique: true,
                filter: "[EnseignatId] IS NOT NULL AND [SalleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Matieres_MatiereId",
                table: "InfoSeances",
                column: "MatiereId",
                principalTable: "Matieres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Matieres_MatiereId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_MatiereId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_EnseignatId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "MatiereId",
                table: "InfoSeances");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "InfoSeances",
                newName: "MatiereRefId");

            migrationBuilder.AddColumn<int>(
                name: "MatiereRefId1",
                table: "InfoSeances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_EnseignatId",
                table: "InfoSeances",
                column: "EnseignatId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_MatiereRefId1",
                table: "InfoSeances",
                column: "MatiereRefId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_MatiereRefs_MatiereRefId1",
                table: "InfoSeances",
                column: "MatiereRefId1",
                principalTable: "MatiereRefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
