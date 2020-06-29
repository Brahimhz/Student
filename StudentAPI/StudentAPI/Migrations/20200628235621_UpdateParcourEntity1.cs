using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateParcourEntity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcours",
                table: "Parcours");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcours",
                table: "Parcours");

            migrationBuilder.DropIndex(
                name: "IX_Parcours_NiveauSpecialiteId",
                table: "Parcours");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Parcours",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcours",
                table: "Parcours",
                columns: new[] { "NiveauSpecialiteId", "EtudientId", "Id" });
        }
    }
}
