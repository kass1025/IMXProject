using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class member_Table_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_GenderId",
                table: "Members",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TitleId",
                table: "Members",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Genders_GenderId",
                table: "Members",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Titles_TitleId",
                table: "Members",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Genders_GenderId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Titles_TitleId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_GenderId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_TitleId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Members");
        }
    }
}
