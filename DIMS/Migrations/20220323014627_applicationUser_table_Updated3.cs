using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class applicationUser_table_Updated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Cities_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Woredas_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "Woredas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Cities_UserLocationId",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Woredas_UserLocationId",
                table: "UserLocations");
        }
    }
}
