using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class EnterpriseandEnterpriseAddressInfo_Table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberTypeId",
                table: "Members",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseName = table.Column<string>(maxLength: 100, nullable: false),
                    TINNumber = table.Column<string>(nullable: true),
                    InitialCapital = table.Column<decimal>(nullable: false),
                    CurrentCapital = table.Column<decimal>(nullable: true),
                    FoundedYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseAddressInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnterpriseAddress = table.Column<string>(maxLength: 200, nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    ZoneId = table.Column<int>(nullable: false),
                    WoredaId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    EnterpriseId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    KebeleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseAddressInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnterpriseAddressInfos_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnterpriseAddressInfos_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnterpriseAddressInfos_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnterpriseAddressInfos_Woredas_WoredaId",
                        column: x => x.WoredaId,
                        principalTable: "Woredas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnterpriseAddressInfos_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberTypeId",
                table: "Members",
                column: "MemberTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddressInfos_CityId",
                table: "MemberAddressInfos",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseAddressInfos_CityId",
                table: "EnterpriseAddressInfos",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseAddressInfos_EnterpriseId",
                table: "EnterpriseAddressInfos",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseAddressInfos_RegionId",
                table: "EnterpriseAddressInfos",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseAddressInfos_WoredaId",
                table: "EnterpriseAddressInfos",
                column: "WoredaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseAddressInfos_ZoneId",
                table: "EnterpriseAddressInfos",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberAddressInfos_Cities_CityId",
                table: "MemberAddressInfos",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members",
                column: "MemberTypeId",
                principalTable: "MemberTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberAddressInfos_Cities_CityId",
                table: "MemberAddressInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_MemberTypes_MemberTypeId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "EnterpriseAddressInfos");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropIndex(
                name: "IX_Members_MemberTypeId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_MemberAddressInfos_CityId",
                table: "MemberAddressInfos");

            migrationBuilder.DropColumn(
                name: "MemberTypeId",
                table: "Members");
        }
    }
}
