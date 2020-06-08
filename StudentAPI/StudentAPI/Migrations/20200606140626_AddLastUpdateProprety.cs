using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class AddLastUpdateProprety : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departements_Personnes_RespCommunicationId",
                table: "Departements");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentPartages_Personnes_PersonneId",
                table: "DocumentPartages");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Personnes_EnseignatId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcours_Personnes_EtudientId",
                table: "Parcours");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationCommunications_Personnes_PersonneId1",
                table: "RelationCommunications");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationCommunications_Personnes_PersonneId2",
                table: "RelationCommunications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personnes",
                table: "Personnes");

            migrationBuilder.RenameTable(
                name: "Personnes",
                newName: "Personne");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "ResultatUnites",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Resultats",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "ResultatMatieres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Planning",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Parcours",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Matieres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "InfoSeances",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "DocumentPartages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Discussions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Personne",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personne",
                table: "Personne",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departements_Personne_RespCommunicationId",
                table: "Departements",
                column: "RespCommunicationId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentPartages_Personne_PersonneId",
                table: "DocumentPartages",
                column: "PersonneId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Personne_EnseignatId",
                table: "InfoSeances",
                column: "EnseignatId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcours_Personne_EtudientId",
                table: "Parcours",
                column: "EtudientId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationCommunications_Personne_PersonneId1",
                table: "RelationCommunications",
                column: "PersonneId1",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationCommunications_Personne_PersonneId2",
                table: "RelationCommunications",
                column: "PersonneId2",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departements_Personne_RespCommunicationId",
                table: "Departements");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentPartages_Personne_PersonneId",
                table: "DocumentPartages");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Personne_EnseignatId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcours_Personne_EtudientId",
                table: "Parcours");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationCommunications_Personne_PersonneId1",
                table: "RelationCommunications");

            migrationBuilder.DropForeignKey(
                name: "FK_RelationCommunications_Personne_PersonneId2",
                table: "RelationCommunications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personne",
                table: "Personne");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ResultatUnites");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Resultats");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ResultatMatieres");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Planning");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Parcours");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Matieres");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "DocumentPartages");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Personne");

            migrationBuilder.RenameTable(
                name: "Personne",
                newName: "Personnes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personnes",
                table: "Personnes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departements_Personnes_RespCommunicationId",
                table: "Departements",
                column: "RespCommunicationId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentPartages_Personnes_PersonneId",
                table: "DocumentPartages",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Personnes_EnseignatId",
                table: "InfoSeances",
                column: "EnseignatId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcours_Personnes_EtudientId",
                table: "Parcours",
                column: "EtudientId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationCommunications_Personnes_PersonneId1",
                table: "RelationCommunications",
                column: "PersonneId1",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RelationCommunications_Personnes_PersonneId2",
                table: "RelationCommunications",
                column: "PersonneId2",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
