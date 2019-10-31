using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class financialinfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    BankName = table.Column<string>(nullable: true),
                    LeaseType = table.Column<string>(nullable: true),
                    LeaseTime = table.Column<int>(nullable: false),
                    LeaseStartDate = table.Column<DateTime>(nullable: false),
                    LeaseEndDate = table.Column<DateTime>(nullable: false),
                    StartNetPrice = table.Column<decimal>(nullable: false),
                    EndBuyoutNetPrice = table.Column<decimal>(nullable: false),
                    MonthlyLeaseFee = table.Column<decimal>(nullable: false),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialInfos_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialInfos_CarId",
                table: "FinancialInfos",
                column: "CarId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialInfos");
        }
    }
}
