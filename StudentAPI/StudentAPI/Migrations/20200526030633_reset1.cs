using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class reset1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
