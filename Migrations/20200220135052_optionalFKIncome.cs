using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class optionalFKIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePolicies_FileDescriptions_FileDescriptionId",
                table: "InsurancePolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceFacilities_ServiceFacilityId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ServiceFacilities");

            migrationBuilder.DropIndex(
                name: "IX_InsurancePolicies_FileDescriptionId",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "FileDescriptionId",
                table: "InsurancePolicies");

            migrationBuilder.RenameColumn(
                name: "ServiceFacilityId",
                table: "Services",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServiceFacilityId",
                table: "Services",
                newName: "IX_Services_ClientId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "InsurancePolicyFile",
                columns: table => new
                {
                    InsurancePolicyId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicyFile", x => new { x.InsurancePolicyId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_InsurancePolicyFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancePolicyFile_InsurancePolicies_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicyFile_FileDescriptionId",
                table: "InsurancePolicyFile",
                column: "FileDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Clients_ClientId",
                table: "Services",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Clients_ClientId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "InsurancePolicyFile");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Services",
                newName: "ServiceFacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ClientId",
                table: "Services",
                newName: "IX_Services_ServiceFacilityId");

            migrationBuilder.AddColumn<Guid>(
                name: "FileDescriptionId",
                table: "InsurancePolicies",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ServiceFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFacilities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePolicies_FileDescriptionId",
                table: "InsurancePolicies",
                column: "FileDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePolicies_FileDescriptions_FileDescriptionId",
                table: "InsurancePolicies",
                column: "FileDescriptionId",
                principalTable: "FileDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceFacilities_ServiceFacilityId",
                table: "Services",
                column: "ServiceFacilityId",
                principalTable: "ServiceFacilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
