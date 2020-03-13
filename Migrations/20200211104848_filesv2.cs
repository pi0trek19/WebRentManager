using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class filesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarExpenses_FileDescriptions_InvoiceId",
                table: "CarExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_FileDescriptions_Cars_CarId",
                table: "FileDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_FileDescriptions_InsuranceClaims_InsuranceClaimId",
                table: "FileDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_FileDescriptions_Rents_RentId",
                table: "FileDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_FileDescriptions_InvoiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_InvoiceId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_FileDescriptions_CarId",
                table: "FileDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_FileDescriptions_InsuranceClaimId",
                table: "FileDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_FileDescriptions_RentId",
                table: "FileDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_CarExpenses_InvoiceId",
                table: "CarExpenses");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "InvoicePath",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "FileDescriptions");

            migrationBuilder.DropColumn(
                name: "InsuranceClaimId",
                table: "FileDescriptions");

            migrationBuilder.DropColumn(
                name: "RentId",
                table: "FileDescriptions");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "CarExpenses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoicePath",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "FileDescriptions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InsuranceClaimId",
                table: "FileDescriptions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RentId",
                table: "FileDescriptions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "CarExpenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_InvoiceId",
                table: "Services",
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

            migrationBuilder.CreateIndex(
                name: "IX_CarExpenses_InvoiceId",
                table: "CarExpenses",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarExpenses_FileDescriptions_InvoiceId",
                table: "CarExpenses",
                column: "InvoiceId",
                principalTable: "FileDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileDescriptions_Cars_CarId",
                table: "FileDescriptions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileDescriptions_InsuranceClaims_InsuranceClaimId",
                table: "FileDescriptions",
                column: "InsuranceClaimId",
                principalTable: "InsuranceClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileDescriptions_Rents_RentId",
                table: "FileDescriptions",
                column: "RentId",
                principalTable: "Rents",
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
    }
}
