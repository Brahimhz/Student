using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateResultatsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ResultatUnites");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ResultatMatieres");

            migrationBuilder.AddColumn<bool>(
                name: "Acquit",
                table: "ResultatUnites",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Acquit",
                table: "Resultats",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Acquit",
                table: "ResultatMatieres",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acquit",
                table: "ResultatUnites");

            migrationBuilder.DropColumn(
                name: "Acquit",
                table: "Resultats");

            migrationBuilder.DropColumn(
                name: "Acquit",
                table: "ResultatMatieres");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "ResultatUnites",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "ResultatMatieres",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
