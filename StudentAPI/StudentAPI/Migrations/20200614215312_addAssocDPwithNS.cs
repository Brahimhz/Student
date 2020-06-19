using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class addAssocDPwithNS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NiveauSpecialiteId",
                table: "DocumentPartages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentPartages_NiveauSpecialiteId",
                table: "DocumentPartages",
                column: "NiveauSpecialiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentPartages_NiveauSpecialites_NiveauSpecialiteId",
                table: "DocumentPartages",
                column: "NiveauSpecialiteId",
                principalTable: "NiveauSpecialites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentPartages_NiveauSpecialites_NiveauSpecialiteId",
                table: "DocumentPartages");

            migrationBuilder.DropIndex(
                name: "IX_DocumentPartages_NiveauSpecialiteId",
                table: "DocumentPartages");

            migrationBuilder.DropColumn(
                name: "NiveauSpecialiteId",
                table: "DocumentPartages");
        }
    }
}
