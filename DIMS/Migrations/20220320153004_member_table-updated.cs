using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class member_tableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnterpriseId",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_EnterpriseId",
                table: "Members",
                column: "EnterpriseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Enterprises_EnterpriseId",
                table: "Members",
                column: "EnterpriseId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Enterprises_EnterpriseId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_EnterpriseId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "EnterpriseId",
                table: "Members");
        }
    }
}
