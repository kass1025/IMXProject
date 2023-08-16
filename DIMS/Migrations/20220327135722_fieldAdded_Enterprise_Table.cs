using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class fieldAdded_Enterprise_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FemaleFounder",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MaleFouder",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "FemaleFounder",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaleFouder",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FemaleFounder",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "MaleFouder",
                table: "Enterprises");

            migrationBuilder.AddColumn<int>(
                name: "FemaleFounder",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaleFouder",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
