using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class Seven_Tables_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchItemId",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CapitalSourceId",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnterpriseLevelId",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnterpriseStatusId",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupTypeId",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromotionLevelId",
                table: "Enterprises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapitalSources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapitalSourceName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapitalSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseLevelName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseStatusName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTypeName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionLeveName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchItemName = table.Column<string>(maxLength: 100, nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchItems_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_BranchItemId",
                table: "Enterprises",
                column: "BranchItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_CapitalSourceId",
                table: "Enterprises",
                column: "CapitalSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_EnterpriseLevelId",
                table: "Enterprises",
                column: "EnterpriseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_EnterpriseStatusId",
                table: "Enterprises",
                column: "EnterpriseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_GroupTypeId",
                table: "Enterprises",
                column: "GroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enterprises_PromotionLevelId",
                table: "Enterprises",
                column: "PromotionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchItems_BranchId",
                table: "BranchItems",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_BranchItems_BranchItemId",
                table: "Enterprises",
                column: "BranchItemId",
                principalTable: "BranchItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_CapitalSources_CapitalSourceId",
                table: "Enterprises",
                column: "CapitalSourceId",
                principalTable: "CapitalSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_EnterpriseLevels_EnterpriseLevelId",
                table: "Enterprises",
                column: "EnterpriseLevelId",
                principalTable: "EnterpriseLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_EnterpriseStatuses_EnterpriseStatusId",
                table: "Enterprises",
                column: "EnterpriseStatusId",
                principalTable: "EnterpriseStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_GroupTypes_GroupTypeId",
                table: "Enterprises",
                column: "GroupTypeId",
                principalTable: "GroupTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enterprises_PromotionLevels_PromotionLevelId",
                table: "Enterprises",
                column: "PromotionLevelId",
                principalTable: "PromotionLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_BranchItems_BranchItemId",
                table: "Enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_CapitalSources_CapitalSourceId",
                table: "Enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_EnterpriseLevels_EnterpriseLevelId",
                table: "Enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_EnterpriseStatuses_EnterpriseStatusId",
                table: "Enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_GroupTypes_GroupTypeId",
                table: "Enterprises");

            migrationBuilder.DropForeignKey(
                name: "FK_Enterprises_PromotionLevels_PromotionLevelId",
                table: "Enterprises");

            migrationBuilder.DropTable(
                name: "BranchItems");

            migrationBuilder.DropTable(
                name: "CapitalSources");

            migrationBuilder.DropTable(
                name: "EnterpriseLevels");

            migrationBuilder.DropTable(
                name: "EnterpriseStatuses");

            migrationBuilder.DropTable(
                name: "GroupTypes");

            migrationBuilder.DropTable(
                name: "PromotionLevels");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_BranchItemId",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_CapitalSourceId",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_EnterpriseLevelId",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_EnterpriseStatusId",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_GroupTypeId",
                table: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Enterprises_PromotionLevelId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "BranchItemId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "CapitalSourceId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "EnterpriseLevelId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "EnterpriseStatusId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "GroupTypeId",
                table: "Enterprises");

            migrationBuilder.DropColumn(
                name: "PromotionLevelId",
                table: "Enterprises");
        }
    }
}
