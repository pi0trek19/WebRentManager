using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class _1710 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HandoverDocument_Rents_RentId",
                table: "HandoverDocument");

            migrationBuilder.DropIndex(
                name: "IX_HandoverDocument_RentId",
                table: "HandoverDocument");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Services",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "InvoicePath",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "HandoverDocumentId",
                table: "Rents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "HandoverId",
                table: "Rents",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialPayment",
                table: "Rents",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsEndDateSet",
                table: "Rents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RentType",
                table: "Rents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentingCompany",
                table: "Rents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserMail",
                table: "Rents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Rents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhone",
                table: "Rents",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarExpenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    CostCategory = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Decription = table.Column<string>(nullable: true),
                    FacilityId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarExpenses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_HandoverId",
                table: "Rents",
                column: "HandoverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_HandoverDocument_HandoverId",
                table: "Rents",
                column: "HandoverId",
                principalTable: "HandoverDocument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_HandoverDocument_HandoverId",
                table: "Rents");

            migrationBuilder.DropTable(
                name: "CarExpenses");

            migrationBuilder.DropIndex(
                name: "IX_Rents_HandoverId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "InvoicePath",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "HandoverDocumentId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "HandoverId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "InitialPayment",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "IsEndDateSet",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "RentType",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "RentingCompany",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "UserMail",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "UserPhone",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_HandoverDocument_RentId",
                table: "HandoverDocument",
                column: "RentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HandoverDocument_Rents_RentId",
                table: "HandoverDocument",
                column: "RentId",
                principalTable: "Rents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
