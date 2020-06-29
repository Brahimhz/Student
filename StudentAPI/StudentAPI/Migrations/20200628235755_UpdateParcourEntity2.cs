using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateParcourEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Parcours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
