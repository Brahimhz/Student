using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class updateModelInfoSeance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Personne_EnseignatId",
                table: "InfoSeances");

            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Journees_JourneeId",
                table: "InfoSeances");

            migrationBuilder.DropTable(
                name: "Journees");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_JourneeId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_EnseignatId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances");

            migrationBuilder.RenameColumn(
                name: "EnseignatId",
                table: "InfoSeances",
                newName: "EnseignantId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_EnseignantId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances",
                columns: new[] { "EnseignantId", "JourneeId", "SeanceId", "SalleId" },
                unique: true,
                filter: "[EnseignantId] IS NOT NULL AND [SalleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Personne_EnseignantId",
                table: "InfoSeances",
                column: "EnseignantId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InfoSeances_Personne_EnseignantId",
                table: "InfoSeances");

            migrationBuilder.DropIndex(
                name: "IX_InfoSeances_EnseignantId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances");

            migrationBuilder.RenameColumn(
                name: "EnseignantId",
                table: "InfoSeances",
                newName: "EnseignatId");

            migrationBuilder.CreateTable(
                name: "Journees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Jour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_JourneeId",
                table: "InfoSeances",
                column: "JourneeId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoSeances_EnseignatId_JourneeId_SeanceId_SalleId",
                table: "InfoSeances",
                columns: new[] { "EnseignatId", "JourneeId", "SeanceId", "SalleId" },
                unique: true,
                filter: "[EnseignatId] IS NOT NULL AND [SalleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Personne_EnseignatId",
                table: "InfoSeances",
                column: "EnseignatId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoSeances_Journees_JourneeId",
                table: "InfoSeances",
                column: "JourneeId",
                principalTable: "Journees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
