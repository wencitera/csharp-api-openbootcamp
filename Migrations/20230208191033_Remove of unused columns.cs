using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstBackend.Migrations
{
    public partial class Removeofunusedcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserDeletorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserUpdatorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserDeletorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserUpdatorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserDeletorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserUpdatorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UserDeletorId",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "UserUpdatorId",
                table: "Chapters");

            migrationBuilder.DropColumn(
                name: "UserDeletorId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserUpdatorId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDeletorId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatorId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDeletorId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatorId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDeletorId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatorId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDeletorId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatorId",
                table: "Chapters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserDeletorId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatorId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
