using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateClassEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefSection",
                table: "SousGroupes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NombreGroupe",
                table: "Sections",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefSection",
                table: "Sections",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NombreSGrope",
                table: "Groupes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefSection",
                table: "Groupes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefSection",
                table: "SousGroupes");

            migrationBuilder.DropColumn(
                name: "RefSection",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "RefSection",
                table: "Groupes");

            migrationBuilder.AlterColumn<string>(
                name: "NombreGroupe",
                table: "Sections",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "NombreSGrope",
                table: "Groupes",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
