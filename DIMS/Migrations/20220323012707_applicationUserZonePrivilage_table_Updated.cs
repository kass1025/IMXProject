using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class applicationUserZonePrivilage_table_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityLocId",
                table: "UserLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_CityLocId",
                table: "UserLocations",
                column: "CityLocId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Cities_CityLocId",
                table: "UserLocations",
                column: "CityLocId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
