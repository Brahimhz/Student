using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateTimeTablesTablev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seances_TimeTables_TimeTableId",
                table: "Seances");

            migrationBuilder.DropColumn(
                name: "TimeTanleId",
                table: "Seances");

            migrationBuilder.AlterColumn<string>(
                name: "Specility",
                table: "TimeTables",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Semester",
                table: "TimeTables",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<string>(
                name: "Cycle",
                table: "TimeTables",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "TimeTables",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "TimeTableId",
                table: "Seances",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Module",
                table: "Seances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Jour",
                table: "Seances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Heure",
                table: "Seances",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_TimeTables_TimeTableId",
                table: "Seances",
                column: "TimeTableId",
                principalTable: "TimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seances_TimeTables_TimeTableId",
                table: "Seances");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "TimeTables");

            migrationBuilder.AlterColumn<string>(
                name: "Specility",
                table: "TimeTables",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte>(
                name: "Semester",
                table: "TimeTables",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cycle",
                table: "TimeTables",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "TimeTableId",
                table: "Seances",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Module",
                table: "Seances",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Jour",
                table: "Seances",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Heure",
                table: "Seances",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "TimeTanleId",
                table: "Seances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Seances_TimeTables_TimeTableId",
                table: "Seances",
                column: "TimeTableId",
                principalTable: "TimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
