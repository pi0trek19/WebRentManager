using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRentManager.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    IsReserved = table.Column<bool>(nullable: false),
                    ReservedUntil = table.Column<DateTime>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    ProductionYear = table.Column<int>(nullable: false),
                    Milage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    IdNumber1 = table.Column<string>(nullable: true),
                    IdNumber2 = table.Column<string>(nullable: true),
                    IdNumber3 = table.Column<string>(nullable: true),
                    RepName = table.Column<string>(nullable: true),
                    RepMail = table.Column<string>(nullable: true),
                    RepPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HandoverDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    RentId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    IsTermAccepted = table.Column<bool>(nullable: false),
                    StartMilage = table.Column<int>(nullable: false),
                    StartFuel = table.Column<int>(nullable: false),
                    StartNotes = table.Column<string>(nullable: true),
                    StartManual = table.Column<bool>(nullable: false),
                    StartService = table.Column<bool>(nullable: false),
                    StartTriangle = table.Column<bool>(nullable: false),
                    StartFireEx = table.Column<bool>(nullable: false),
                    StartSpare = table.Column<bool>(nullable: false),
                    StartRepairSet = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StartCientSignature = table.Column<string>(nullable: true),
                    StartCompanySignature = table.Column<string>(nullable: true),
                    EndMilage = table.Column<int>(nullable: false),
                    EndFuel = table.Column<int>(nullable: false),
                    EndNotes = table.Column<string>(nullable: true),
                    EndManual = table.Column<bool>(nullable: false),
                    EndService = table.Column<bool>(nullable: false),
                    EndTriangle = table.Column<bool>(nullable: false),
                    EndFireEx = table.Column<bool>(nullable: false),
                    EndSpare = table.Column<bool>(nullable: false),
                    EndRepairSet = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EndClientSignature = table.Column<string>(nullable: true),
                    EndCompanySignature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandoverDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFacilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFacilities", x => x.Id);
                });

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
                name: "CarDamages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    DamageType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OffsetX = table.Column<double>(nullable: false),
                    OffsetY = table.Column<double>(nullable: false),
                    PhotoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDamages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDamages_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "MilageRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Milage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilageRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilageRecords_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    HandoverDocumentId = table.Column<Guid>(nullable: false),
                    RentType = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RentFee = table.Column<decimal>(nullable: false),
                    DamageFee = table.Column<int>(nullable: false),
                    MilageLimit = table.Column<int>(nullable: false),
                    OverMilageFee = table.Column<decimal>(nullable: false),
                    InitialPayment = table.Column<decimal>(nullable: false),
                    TyresIncluded = table.Column<bool>(nullable: false),
                    ServiceIncluded = table.Column<bool>(nullable: false),
                    AssistanceIncluded = table.Column<bool>(nullable: false),
                    ReplacementCarIncluded = table.Column<bool>(nullable: false),
                    IsFinished = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsEndDateSet = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserPhone = table.Column<string>(nullable: true),
                    UserMail = table.Column<string>(nullable: true),
                    RentingCompany = table.Column<int>(nullable: false),
                    HandoverDocumentId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_HandoverDocuments_HandoverDocumentId1",
                        column: x => x.HandoverDocumentId1,
                        principalTable: "HandoverDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Milage = table.Column<int>(nullable: false),
                    ServiceFacilityId = table.Column<Guid>(nullable: false),
                    ServiceType = table.Column<int>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    InvoicePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_ServiceFacilities_ServiceFacilityId",
                        column: x => x.ServiceFacilityId,
                        principalTable: "ServiceFacilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Dot = table.Column<int>(nullable: false),
                    TyreType = table.Column<int>(nullable: false),
                    TyreStatus = table.Column<int>(nullable: false)
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
                name: "IX_CarDamages_CarId",
                table: "CarDamages",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialInfos_CarId",
                table: "FinancialInfos",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilageRecords_CarId",
                table: "MilageRecords",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_HandoverDocumentId1",
                table: "Rents",
                column: "HandoverDocumentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CarId",
                table: "Services",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceFacilityId",
                table: "Services",
                column: "ServiceFacilityId");

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
                name: "CarDamages");

            migrationBuilder.DropTable(
                name: "CarExpenses");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "FinancialInfos");

            migrationBuilder.DropTable(
                name: "MilageRecords");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "TyreInfos");

            migrationBuilder.DropTable(
                name: "HandoverDocuments");

            migrationBuilder.DropTable(
                name: "ServiceFacilities");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "TyreShops");
        }
    }
}
