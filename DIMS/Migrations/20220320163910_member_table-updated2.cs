using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class member_tableupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Disabilities_DisabilityId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "DisabilityId",
                table: "Members",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Disabilities_DisabilityId",
                table: "Members",
                column: "DisabilityId",
                principalTable: "Disabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Disabilities_DisabilityId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "DisabilityId",
                table: "Members",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Disabilities_DisabilityId",
                table: "Members",
                column: "DisabilityId",
                principalTable: "Disabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
