using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAPI.Migrations
{
    public partial class UpdateSeanceTablev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seances_TimeTableId",
                table: "Seances");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Seances_TimeTableId_Jour_Heure",
                table: "Seances",
                columns: new[] { "TimeTableId", "Jour", "Heure" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Seances_TimeTableId_Jour_Heure",
                table: "Seances");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_TimeTableId",
                table: "Seances",
                column: "TimeTableId");
        }
    }
}
