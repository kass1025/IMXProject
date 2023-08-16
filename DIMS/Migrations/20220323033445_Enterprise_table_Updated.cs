using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class Enterprise_table_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "UserLocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_EnterpriseId",
                table: "UserLocations",
                column: "EnterpriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Enterprises_EnterpriseId",
                table: "UserLocations",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Enterprises_EnterpriseId",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_UserLocations_EnterpriseId",
                table: "UserLocations");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "UserLocations");
        }
    }
}
