using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class tyreInfoAddes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TyreShops",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WeekHours = table.Column<string>(nullable: true),
                    SaturdayHours = table.Column<string>(nullable: true),
                    SundayHours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyreShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TyreInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    TyreShopId = table.Column<Guid>(nullable: false),
                    TyreName = table.Column<string>(nullable: true),
                    Diameter = table.Column<int>(nullable: false),
                    Profile = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    SpeedIndex = table.Column<string>(nullable: true),
                    Dot = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyreInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TyreInfos_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TyreInfos_TyreShops_TyreShopId",
                        column: x => x.TyreShopId,
                        principalTable: "TyreShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TyreInfos_CarId",
                table: "TyreInfos",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_TyreInfos_TyreShopId",
                table: "TyreInfos",
                column: "TyreShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TyreInfos");

            migrationBuilder.DropTable(
                name: "TyreShops");
        }
    }
}
