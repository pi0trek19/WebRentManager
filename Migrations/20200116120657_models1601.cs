using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class models1601 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsuranceVallidTo",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "CarExpenses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InsuranceClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    InsuranceCompany = table.Column<string>(nullable: true),
                    RepresentativeName = table.Column<string>(nullable: true),
                    RepresentativePhone = table.Column<string>(nullable: true),
                    RepresentativeMail = table.Column<string>(nullable: true),
                    ClaimNo = table.Column<string>(nullable: true),
                    ClaimType = table.Column<int>(nullable: false),
                    ClaimStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Ext = table.Column<string>(nullable: true),
                    FileType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    CarId = table.Column<Guid>(nullable: true),
                    InsuranceClaimId = table.Column<Guid>(nullable: true),
                    RentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileDescriptions_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileDescriptions_InsuranceClaims_InsuranceClaimId",
                        column: x => x.InsuranceClaimId,
                        principalTable: "InsuranceClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileDescriptions_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_InvoiceId",
                table: "Services",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CarExpenses_InvoiceId",
                table: "CarExpenses",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptions_CarId",
                table: "FileDescriptions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptions_InsuranceClaimId",
                table: "FileDescriptions",
                column: "InsuranceClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_FileDescriptions_RentId",
                table: "FileDescriptions",
                column: "RentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarExpenses_FileDescriptions_InvoiceId",
                table: "CarExpenses",
                column: "InvoiceId",
                principalTable: "FileDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_FileDescriptions_InvoiceId",
                table: "Services",
                column: "InvoiceId",
                principalTable: "FileDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarExpenses_FileDescriptions_InvoiceId",
                table: "CarExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_FileDescriptions_InvoiceId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "FileDescriptions");

            migrationBuilder.DropTable(
                name: "InsuranceClaims");

            migrationBuilder.DropIndex(
                name: "IX_Services_InvoiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_CarExpenses_InvoiceId",
                table: "CarExpenses");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "InsuranceVallidTo",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "CarExpenses");
        }
    }
}
