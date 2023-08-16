using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class newfieldAdded_UserAccount_Tabledd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FemaleCollege",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FemaleUniversity",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaleCollege",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaleUniversity",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FemaleCollege",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "FemaleUniversity",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "MaleCollege",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "MaleUniversity",
                table: "Enterprises");
        }
    }
}
