using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class disability_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disabilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisabilityName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disabilities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_DisabilityId",
                table: "Members",
                column: "DisabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Disabilities_DisabilityId",
                table: "Members",
                column: "DisabilityId",
                principalTable: "Disabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Disabilities_DisabilityId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Disabilities");

            migrationBuilder.DropIndex(
                name: "IX_Members_DisabilityId",
                table: "Members");
        }
    }
}
