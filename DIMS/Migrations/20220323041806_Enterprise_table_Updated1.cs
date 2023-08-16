using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class Enterprise_table_Updated1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_UserLocations_EnterpriseId",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_EnterpriseId",
                table: "UserLocations");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "UserLocations");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_UserLocations_UserLocationId",
                table: "UserLocations",
                column: "UserLocationId",
                principalTable: "UserLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_UserLocations_UserLocationId",
                table: "UserLocations");

            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "UserLocations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_EnterpriseId",
                table: "UserLocations",
                column: "EnterpriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_UserLocations_EnterpriseId",
                table: "UserLocations",
                column: "EnterpriseId",
                principalTable: "UserLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
