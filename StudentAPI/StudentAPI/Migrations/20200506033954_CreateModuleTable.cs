using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class CreateModuleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specility",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "Module",
                table: "Seances");

            migrationBuilder.AlterColumn<string>(
                name: "Semester",
                table: "TimeTables",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "SchoolYear",
                table: "TimeTables",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cycle",
                table: "TimeTables",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ClassNbr",
                table: "TimeTables",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "TimeTables",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Seances",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lieu",
                table: "Seances",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Jour",
                table: "Seances",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Heure",
                table: "Seances",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "Seances",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolYear = table.Column<string>(maxLength: 20, nullable: true),
                    Cycle = table.Column<string>(maxLength: 20, nullable: false),
                    Semester = table.Column<string>(maxLength: 2, nullable: false),
                    Speciality = table.Column<string>(maxLength: 50, nullable: false),
                    ClassNbr = table.Column<string>(maxLength: 2, nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AbvNom = table.Column<string>(maxLength: 10, nullable: true),
                    Unite = table.Column<string>(maxLength: 50, nullable: false),
                    Coefficient = table.Column<int>(nullable: false),
                    Credit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seances_ModuleId",
                table: "Seances",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_Modules_ModuleId",
                table: "Seances",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seances_Modules_ModuleId",
                table: "Seances");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Seances_ModuleId",
                table: "Seances");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Seances");

            migrationBuilder.AlterColumn<string>(
                name: "Semester",
                table: "TimeTables",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolYear",
                table: "TimeTables",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cycle",
                table: "TimeTables",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ClassNbr",
                table: "TimeTables",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specility",
                table: "TimeTables",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Seances",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lieu",
                table: "Seances",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Jour",
                table: "Seances",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Heure",
                table: "Seances",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "Module",
                table: "Seances",
                nullable: false,
                defaultValue: "");
        }
    }
}
