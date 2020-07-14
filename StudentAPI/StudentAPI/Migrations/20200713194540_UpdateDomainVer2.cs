using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateDomainVer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_MatiereRefs_MatiereRefId1",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_Journees_Planning_PlanningId",
                table: "Journees");

            migrationBuilder.DropForeignKey(
                name: "FK_Seances_InfoSeances_InfoSeanceId",
                table: "Seances");

            migrationBuilder.DropForeignKey(
                name: "FK_Seances_Journees_JourneeId",
                table: "Seances");

            migrationBuilder.DropIndex(
                name: "IX_Seances_InfoSeanceId",
                table: "Seances");

            migrationBuilder.DropIndex(
                name: "IX_Seances_JourneeId",
                table: "Seances");

            migrationBuilder.DropIndex(
                name: "IX_Journees_PlanningId",
                table: "Journees");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_MatiereRefId1",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Planning");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "MatiereRefId1",
                table: "InfoSeances");

            migrationBuilder.AddColumn<int>(
                name: "JourneeId",
                table: "InfoSeances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanningId",
                table: "InfoSeances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeanceId1",
                table: "InfoSeances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_Id",
                table: "InfoSeances",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_JourneeId",
                table: "InfoSeances",
                column: "JourneeId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_PlanningId",
                table: "InfoSeances",
                column: "PlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_SeanceId",
                table: "InfoSeances",
                column: "SeanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Matieres_Id",
                table: "InfoSeances",
                column: "Id",
                principalTable: "Matieres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Journees_JourneeId",
                table: "InfoSeances",
                column: "JourneeId",
                principalTable: "Journees",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Matieres_Id",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Journees_JourneeId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Planning_PlanningId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Seances_SeanceId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_Id",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_JourneeId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_PlanningId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_SeanceId",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "JourneeId",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "PlanningId",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "SeanceId1",
                table: "InfoSeances");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Planning",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "InfoSeances",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MatiereRefId1",
                table: "InfoSeances",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seances_InfoSeanceId",
                table: "Seances",
                column: "InfoSeanceId",
                unique: true,
                filter: "[InfoSeanceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_JourneeId",
                table: "Seances",
                column: "JourneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Journees_PlanningId",
                table: "Journees",
                column: "PlanningId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Journees_Planning_PlanningId",
                table: "Journees",
                column: "PlanningId",
                principalTable: "Planning",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_InfoSeances_InfoSeanceId",
                table: "Seances",
                column: "InfoSeanceId",
                principalTable: "InfoSeances",
                principalColumn: "MatiereRefId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_Journees_JourneeId",
                table: "Seances",
                column: "JourneeId",
                principalTable: "Journees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
