using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class Enterprise_table_Updated123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_UserLocations_UserLocationId",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_UserLocationId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "UserLocationId",
                table: "Enterprises");

            migrationBuilder.AddColumn<int>(
                name: "EnterUserLocationId",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_EnterUserLocationId",
                table: "Enterprises",
                column: "EnterUserLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_UserLocations_EnterUserLocationId",
                table: "Enterprises",
                column: "EnterUserLocationId",
                principalTable: "UserLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_UserLocations_EnterUserLocationId",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_EnterUserLocationId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "EnterUserLocationId",
                table: "Enterprises");

            migrationBuilder.AddColumn<int>(
                name: "UserLocationId",
                table: "Enterprises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_UserLocationId",
                table: "Enterprises",
                column: "UserLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_UserLocations_UserLocationId",
                table: "Enterprises",
                column: "UserLocationId",
                principalTable: "UserLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
