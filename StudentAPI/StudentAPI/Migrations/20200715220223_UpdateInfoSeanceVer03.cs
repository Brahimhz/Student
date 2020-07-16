using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateInfoSeanceVer03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Journees_JourneeId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Matieres_MatiereId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Planning_PlanningId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Seances_SeanceId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_EnseignatId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances");

            migrationBuilder.AlterColumn<int>(
                name: "SeanceId",
                table: "InfoSeances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PlanningId",
                table: "InfoSeances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MatiereId",
                table: "InfoSeances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "JourneeId",
                table: "InfoSeances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_EnseignatId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances",
                columns: new[] { "EnseignatId", "JourneeId", "SeanceId", "SalleId" },
                unique: true,
                filter: "[EnseignatId] IS NOT NULL AND [JourneeId] IS NOT NULL AND [SeanceId] IS NOT NULL AND [SalleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Journees_JourneeId",
                table: "InfoSeances",
                column: "JourneeId",
                principalTable: "Journees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Matieres_MatiereId",
                table: "InfoSeances",
                column: "MatiereId",
                principalTable: "Matieres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Planning_PlanningId",
                table: "InfoSeances",
                column: "PlanningId",
                principalTable: "Planning",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Seances_SeanceId",
                table: "InfoSeances",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Journees_JourneeId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Matieres_MatiereId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Planning_PlanningId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Seances_SeanceId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_EnseignatId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances");

            migrationBuilder.AlterColumn<int>(
                name: "SeanceId",
                table: "InfoSeances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanningId",
                table: "InfoSeances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatiereId",
                table: "InfoSeances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JourneeId",
                table: "InfoSeances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_EnseignatId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances",
                columns: new[] { "EnseignatId", "JourneeId", "SeanceId", "SalleId" },
                unique: true,
                filter: "[EnseignatId] IS NOT NULL AND [SalleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Journees_JourneeId",
                table: "InfoSeances",
                column: "JourneeId",
                principalTable: "Journees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Matieres_MatiereId",
                table: "InfoSeances",
                column: "MatiereId",
                principalTable: "Matieres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Planning_PlanningId",
                table: "InfoSeances",
                column: "PlanningId",
                principalTable: "Planning",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Seances_SeanceId",
                table: "InfoSeances",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
