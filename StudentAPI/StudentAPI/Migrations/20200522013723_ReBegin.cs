using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class ReBegin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "ExamTables");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "TimeTables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassNbr = table.Column<string>(maxLength: 2, nullable: true),
                    Cycle = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    SchoolYear = table.Column<string>(maxLength: 20, nullable: true),
                    Semester = table.Column<string>(maxLength: 2, nullable: false),
                    Speciality = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbvNom = table.Column<string>(maxLength: 10, nullable: true),
                    Coefficient = table.Column<int>(nullable: false),
                    Credit = table.Column<int>(nullable: false),
                    Cycle = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Semester = table.Column<string>(maxLength: 2, nullable: false),
                    Speciality = table.Column<string>(maxLength: 50, nullable: false),
                    Unite = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassNbr = table.Column<string>(maxLength: 2, nullable: true),
                    Cycle = table.Column<string>(maxLength: 20, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    SchoolYear = table.Column<string>(maxLength: 20, nullable: true),
                    Semester = table.Column<string>(maxLength: 2, nullable: false),
                    Speciality = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ExamTableId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    Time = table.Column<string>(maxLength: 5, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<string>(maxLength: 15, nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    ModuleId = table.Column<int>(nullable: false),
                    Time = table.Column<string>(maxLength: 5, nullable: false),
                    TimeTableId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.Id);
                    table.UniqueConstraint("AK_Seances_TimeTableId_Day_Time", x => new { x.TimeTableId, x.Day, x.Time });
                    table.ForeignKey(
                        name: "FK_Seances_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_TimeTables_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "TimeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ModuleId",
                table: "Exams",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_ModuleId",
                table: "Seances",
                column: "ModuleId");
        }
    }
}
