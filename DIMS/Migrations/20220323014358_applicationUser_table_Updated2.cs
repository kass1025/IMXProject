using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class applicationUser_table_Updated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Regions_RegionId",
                table: "UserLocations");

            
            migrationBuilder.DropIndex(
                name: "IX_UserLocations_RegionId",
                table: "UserLocations");


            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "UserLocations");

            migrationBuilder.AddColumn<int>(
                name: "UserLocationId",
                table: "UserLocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Regions_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Zones_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Regions_UserLocationId",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Zones_UserLocationId",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_UserLocationId",
                table: "UserLocations");

            migrationBuilder.DropColumn(
                name: "UserLocationId",
                table: "UserLocations");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "UserLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "UserLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_RegionId",
                table: "UserLocations",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_ZoneId",
                table: "UserLocations",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Regions_RegionId",
                table: "UserLocations",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Zones_ZoneId",
                table: "UserLocations",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
