using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateMatiereEntityVer02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Matieres",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matieres",
                table: "Matieres",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResultatMatieres_MatiereId",
                table: "ResultatMatieres",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Matieres_MatiereRefId",
                table: "Matieres",
                column: "MatiereRefId");

            migrationBuilder.AddForeignKey(
                            name: "FK_ResultatMatieres_Matieres_MatiereId",
                            table: "ResultatMatieres",
                            column: "MatiereId",
                            principalTable: "Matieres",
                            principalColumn: "Id",
                            onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
