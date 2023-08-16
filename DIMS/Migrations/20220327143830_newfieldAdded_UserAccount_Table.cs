using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class newfieldAdded_UserAccount_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Cities_UserLocationId",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Woredas_UserLocationId",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Zones_UserLocationId",
                table: "UserLocations");

            migrationBuilder.AlterColumn<int>(
                name: "UserLocationId",
                table: "UserLocations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Cities_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Woredas_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "Woredas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Zones_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Cities_UserLocationId",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Woredas_UserLocationId",
                table: "UserLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Zones_UserLocationId",
                table: "UserLocations");

            migrationBuilder.AlterColumn<int>(
                name: "UserLocationId",
                table: "UserLocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Zones_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
