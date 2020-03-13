using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class allFileRepositories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "CarDamages");

            migrationBuilder.CreateTable(
                name: "CarDamageFile",
                columns: table => new
                {
                    CarDamageId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDamageFile", x => new { x.CarDamageId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_CarDamageFile_CarDamages_CarDamageId",
                        column: x => x.CarDamageId,
                        principalTable: "CarDamages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarDamageFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarExpenseFile",
                columns: table => new
                {
                    CarExpenseId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarExpenseFile", x => new { x.CarExpenseId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_CarExpenseFile_CarExpenses_CarExpenseId",
                        column: x => x.CarExpenseId,
                        principalTable: "CarExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarExpenseFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientFile",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFile", x => new { x.ClientId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_ClientFile_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HandoverDocumentFile",
                columns: table => new
                {
                    HandoverDocumentId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandoverDocumentFile", x => new { x.HandoverDocumentId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_HandoverDocumentFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HandoverDocumentFile_HandoverDocuments_HandoverDocumentId",
                        column: x => x.HandoverDocumentId,
                        principalTable: "HandoverDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceClaimFile",
                columns: table => new
                {
                    InsuranceClaimId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceClaimFile", x => new { x.InsuranceClaimId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_InsuranceClaimFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceClaimFile_InsuranceClaims_InsuranceClaimId",
                        column: x => x.InsuranceClaimId,
                        principalTable: "InsuranceClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentFile",
                columns: table => new
                {
                    RentId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentFile", x => new { x.RentId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_RentFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentFile_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFile",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(nullable: false),
                    FileDescriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFile", x => new { x.ServiceId, x.FileDescriptionId });
                    table.ForeignKey(
                        name: "FK_ServiceFile_FileDescriptions_FileDescriptionId",
                        column: x => x.FileDescriptionId,
                        principalTable: "FileDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceFile_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDamageFile_FileDescriptionId",
                table: "CarDamageFile",
                column: "FileDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarExpenseFile_FileDescriptionId",
                table: "CarExpenseFile",
                column: "FileDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFile_FileDescriptionId",
                table: "ClientFile",
                column: "FileDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_HandoverDocumentFile_FileDescriptionId",
                table: "HandoverDocumentFile",
                column: "FileDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceClaimFile_FileDescriptionId",
                table: "InsuranceClaimFile",
                column: "FileDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RentFile_FileDescriptionId",
                table: "RentFile",
                column: "FileDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFile_FileDescriptionId",
                table: "ServiceFile",
                column: "FileDescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDamageFile");

            migrationBuilder.DropTable(
                name: "CarExpenseFile");

            migrationBuilder.DropTable(
                name: "ClientFile");

            migrationBuilder.DropTable(
                name: "HandoverDocumentFile");

            migrationBuilder.DropTable(
                name: "InsuranceClaimFile");

            migrationBuilder.DropTable(
                name: "RentFile");

            migrationBuilder.DropTable(
                name: "ServiceFile");

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "CarDamages",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
