using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class fnewieldAdded_Enterprise_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FemaleFounderYear",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaleFouderYear",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FemaleFounderYear",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "MaleFouderYear",
                table: "Enterprises");
        }
    }
}
