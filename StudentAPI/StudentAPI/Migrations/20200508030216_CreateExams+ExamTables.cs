using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class CreateExamsExamTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Seances_TimeTableId_Jour_Heure",
                table: "Seances");

            migrationBuilder.RenameColumn(
                name: "Lieu",
                table: "Seances",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Jour",
                table: "Seances",
                newName: "Day");

            migrationBuilder.RenameColumn(
                name: "Heure",
                table: "Seances",
                newName: "Time");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Seances_TimeTableId_Day_Time",
                table: "Seances",
                columns: new[] { "TimeTableId", "Day", "Time" });

            migrationBuilder.CreateTable(
                name: "ExamTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolYear = table.Column<string>(maxLength: 20, nullable: true),
                    Cycle = table.Column<string>(maxLength: 20, nullable: false),
                    Semester = table.Column<string>(maxLength: 2, nullable: false),
                    Speciality = table.Column<string>(maxLength: 50, nullable: false),
                    ClassNbr = table.Column<string>(maxLength: 2, nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(maxLength: 5, nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    ExamTableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.UniqueConstraint("AK_Exams_ExamTableId_Date_Time", x => new { x.ExamTableId, x.Date, x.Time });
                    table.ForeignKey(
                        name: "FK_Exams_ExamTables_ExamTableId",
                        column: x => x.ExamTableId,
                        principalTable: "ExamTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ModuleId",
                table: "Exams",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "ExamTables");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Seances_TimeTableId_Day_Time",
                table: "Seances");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Seances",
                newName: "Heure");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Seances",
                newName: "Lieu");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Seances",
                newName: "Jour");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Seances_TimeTableId_Jour_Heure",
                table: "Seances",
                columns: new[] { "TimeTableId", "Jour", "Heure" });
        }
    }
}
