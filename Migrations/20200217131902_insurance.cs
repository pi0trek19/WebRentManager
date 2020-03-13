using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class insurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceVallidTo",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "Services",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "InsurancePolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    InsuranceCompany = table.Column<string>(nullable: true),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancePolicies_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    InvoiceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_InvoiceId",
                table: "Services",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_CarId",
                table: "InsurancePolicies",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_FileDescriptionId",
                table: "InsurancePolicies",
                column: "FileDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_FileDescriptionId",
                table: "Invoices",
                column: "FileDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Invoices_InvoiceId",
                table: "Services",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Invoices_InvoiceId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Services_InvoiceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Services");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsuranceVallidTo",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
