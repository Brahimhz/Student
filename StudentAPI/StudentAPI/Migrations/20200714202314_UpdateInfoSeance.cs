using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateInfoSeance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_RelationCommunications_RelationCommunicationPersonneId1_RelationCommunicationPersonneId2",
                table: "Discussions");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Matieres_Id",
                table: "InfoSeances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelationCommunications",
                table: "RelationCommunications");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_Id",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_RelationCommunicationPersonneId1_RelationCommunicationPersonneId2",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "SeanceId1",
                table: "InfoSeances");

            migrationBuilder.DropColumn(
                name: "RelationCommunicationPersonneId1",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "RelationCommunicationPersonneId2",
                table: "Discussions");



            migrationBuilder.AddPrimaryKey(
                name: "PK_RelationCommunications",
                table: "RelationCommunications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RelationCommunications_PersonneId1_PersonneId2",
                table: "RelationCommunications",
                columns: new[] { "PersonneId1", "PersonneId2" },
                unique: true);



            migrationBuilder.CreateIndex(
                name: "IX_Discussions_RelationCommunicationId",
                table: "Discussions",
                column: "RelationCommunicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_RelationCommunications_RelationCommunicationId",
                table: "Discussions",
                column: "RelationCommunicationId",
                principalTable: "RelationCommunications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussions_RelationCommunications_RelationCommunicationId",
                table: "Discussions");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_MatiereRefs_MatiereRefId1",
                table: "InfoSeances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelationCommunications",
                table: "RelationCommunications");

            migrationBuilder.DropIndex(
                name: "IX_RelationCommunications_PersonneId1_PersonneId2",
                table: "RelationCommunications");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_MatiereRefId1",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_Discussions_RelationCommunicationId",
                table: "Discussions");

            migrationBuilder.DropColumn(
                name: "MatiereRefId1",
                table: "InfoSeances");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RelationCommunications",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InfoSeances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeanceId1",
                table: "InfoSeances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelationCommunicationPersonneId1",
                table: "Discussions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelationCommunicationPersonneId2",
                table: "Discussions",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelationCommunications",
                table: "RelationCommunications",
                columns: new[] { "PersonneId1", "PersonneId2" });

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_Id",
                table: "InfoSeances",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_RelationCommunicationPersonneId1_RelationCommunicationPersonneId2",
                table: "Discussions",
                columns: new[] { "RelationCommunicationPersonneId1", "RelationCommunicationPersonneId2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_RelationCommunications_RelationCommunicationPersonneId1_RelationCommunicationPersonneId2",
                table: "Discussions",
                columns: new[] { "RelationCommunicationPersonneId1", "RelationCommunicationPersonneId2" },
                principalTable: "RelationCommunications",
                principalColumns: new[] { "PersonneId1", "PersonneId2" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Matieres_Id",
                table: "InfoSeances",
                column: "Id",
                principalTable: "Matieres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
