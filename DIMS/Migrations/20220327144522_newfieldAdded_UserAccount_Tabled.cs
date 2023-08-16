using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class newfieldAdded_UserAccount_Tabled : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_UserLocationId",
                table: "UserLocations");

            migrationBuilder.AlterColumn<int>(
                name: "UserLocationId",
                table: "UserLocations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserLocationId",
                table: "UserLocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId");

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
    }
}
