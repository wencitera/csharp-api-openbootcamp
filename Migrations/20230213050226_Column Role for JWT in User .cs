using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstBackend.Migrations
{
    public partial class ColumnRoleforJWTinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters",
                column: "CourseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_CourseId",
                table: "Chapters",
                column: "CourseId");
        }
    }
}
