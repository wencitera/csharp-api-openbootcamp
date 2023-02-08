using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstBackend.Migrations
{
    public partial class RemoveChapter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters",
                column: "CourseId",
                unique: true);
        }
    }
}
