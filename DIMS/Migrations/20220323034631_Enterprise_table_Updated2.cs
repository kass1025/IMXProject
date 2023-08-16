using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class Enterprise_table_Updated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_Enterprises_EnterpriseId",
                table: "UserLocations");

            migrationBuilder.AlterColumn<int>(
                name: "EnterpriseId",
                table: "UserLocations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserLocationId",
                table: "Enterprises",
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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_UserLocations_EnterpriseId",
                table: "UserLocations",
                column: "EnterpriseId",
                principalTable: "UserLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_UserLocations_UserLocationId",
                table: "Enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLocations_UserLocations_EnterpriseId",
                table: "UserLocations");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_UserLocationId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "UserLocationId",
                table: "Enterprises");

            migrationBuilder.AlterColumn<int>(
                name: "EnterpriseId",
                table: "UserLocations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLocations_Enterprises_EnterpriseId",
                table: "UserLocations",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
