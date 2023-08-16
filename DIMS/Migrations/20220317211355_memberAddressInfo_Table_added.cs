using Microsoft.EntityFrameworkCore.Migrations;

namespace DIMS.Migrations
{
    public partial class memberAddressInfo_Table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberAddressInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberAddress = table.Column<string>(maxLength: 200, nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    ZoneId = table.Column<int>(nullable: false),
                    WoredaId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    KebeleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAddressInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberAddressInfos_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MemberAddressInfos_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MemberAddressInfos_Woredas_WoredaId",
                        column: x => x.WoredaId,
                        principalTable: "Woredas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MemberAddressInfos_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddressInfos_MemberId",
                table: "MemberAddressInfos",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddressInfos_RegionId",
                table: "MemberAddressInfos",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddressInfos_WoredaId",
                table: "MemberAddressInfos",
                column: "WoredaId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddressInfos_ZoneId",
                table: "MemberAddressInfos",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberAddressInfos");
        }
    }
}
