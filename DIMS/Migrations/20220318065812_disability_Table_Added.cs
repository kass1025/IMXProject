using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class disability_Table_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisasterMembers");

            migrationBuilder.DropTable(
                name: "DisasterOnDuts");

            migrationBuilder.DropTable(
                name: "DisasterTypes");

            migrationBuilder.AddColumn<int>(
                name: "DisabilityId",
                table: "Members",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisabilityId",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "DisasterOnDuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateHapped = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisasterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisasterTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisasterOnDuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisasterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisasterTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisasterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisasterMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateHapped = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisasterOnDutyId = table.Column<int>(type: "int", nullable: false),
                    DisasterTypeId = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisasterMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisasterMembers_DisasterOnDuts_DisasterOnDutyId",
                        column: x => x.DisasterOnDutyId,
                        principalTable: "DisasterOnDuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisasterMembers_DisasterTypes_DisasterTypeId",
                        column: x => x.DisasterTypeId,
                        principalTable: "DisasterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisasterMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisasterMembers_DisasterOnDutyId",
                table: "DisasterMembers",
                column: "DisasterOnDutyId");

            migrationBuilder.CreateIndex(
                name: "IX_DisasterMembers_DisasterTypeId",
                table: "DisasterMembers",
                column: "DisasterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DisasterMembers_MemberId",
                table: "DisasterMembers",
                column: "MemberId");
        }
    }
}
